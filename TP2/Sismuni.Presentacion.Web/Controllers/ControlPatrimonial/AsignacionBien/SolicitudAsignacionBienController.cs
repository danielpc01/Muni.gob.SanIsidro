using Sismuni.Dominio.Entidad.ControlPatrimonial;
using Sismuni.Dominio.Entidad.General;
using Sismuni.Dominio.Negocio.ControlPatrimonial;
using Sismuni.Dominio.Negocio.General;
using Sismuni.Presentacion.Web.Controllers.General;
using Sismuni.Presentacion.Web.Models.ControlPatrimonial.AsignacionBien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Sismuni.Presentacion.Web.Controllers.ControlPatrimonial.AsignacionBien
{
    public class SolicitudAsignacionBienController : BaseController
    {
        //
        // GET: /SolicitudAsignacionBien/
        public ActionResult Index(string submit2, SolicitudAsignacionBienMuebleVob SolicitudAsignacion, AsignacionBienMuebleVob AsignacionBienMueble, int id = 0)
        {
            try
            {
                var areaNegocio = new GCPAreaNegocio();
                var trabajadorNegocio = new GCPUsuarioTrabajadorNegocio();
                var bienNegocio = new GCPBienMuebleNegocio();
                var solicitudNegocio = new GCPSolicitudAsignacionBienMuebleNegocio();

                var solicitudAsignacionVM = new SolicitudAsignacionBienViewModel();

                SolicitudAsignacion.AsignacionBienMueble = new List<AsignacionBienMuebleVob>();

                //if (ModelState.IsValid)
                //{

                //if (SolicitudAsignacion.NroSolicitudAsignacion == 0 && id == 0)
                //    solicitudAsignacionVM.ListaSolicitudes = solicitudNegocio.SelectAll();
                //else
                //{
                //    SolicitudAsignacionBienMuebleVob solicitud = solicitudNegocio.Select(id > 0 && string.IsNullOrEmpty(submit2) ? id : SolicitudAsignacion.NroSolicitudAsignacion);

                //    if (solicitud != null)
                //    {
                //        List<SolicitudAsignacionBienMuebleVob> listaSolicitudes = new List<SolicitudAsignacionBienMuebleVob>();
                //        SolicitudAsignacion = solicitud;
                //        listaSolicitudes.Add(SolicitudAsignacion);
                //        solicitudAsignacionVM.ListaSolicitudes = listaSolicitudes;
                //    }
                //    else
                //        solicitudAsignacionVM.ListaSolicitudes = solicitudNegocio.SelectAll();
                //}

                solicitudAsignacionVM.ListaSolicitudes = solicitudNegocio.SelectAll();
                solicitudAsignacionVM.ListaBienes = bienNegocio.SelectAll();
                solicitudAsignacionVM.ListaAreas = areaNegocio.SelectAll();

                if (submit2 == "Buscar" || id > 0)
                {
                    SolicitudAsignacionBienMuebleVob solicitud = solicitudNegocio.Select(id > 0 && string.IsNullOrEmpty(submit2) ? id : SolicitudAsignacion.NroSolicitudAsignacion);
                    if (solicitud != null)
                        SolicitudAsignacion = solicitud;
                }

                if (submit2 == "Agregar")
                {
                    ICollection<AsignacionBienMuebleVob> asig = GetCache<ICollection<AsignacionBienMuebleVob>>(SolicitudAsignacion.AsignacionBienMueble);
                    if (asig.Count == 0)
                        SolicitudAsignacion.AsignacionBienMueble = new List<AsignacionBienMuebleVob>();
                    else
                        SolicitudAsignacion.AsignacionBienMueble = asig;

                    AsignacionBienMueble.BienMueble = new BienMuebleVob();
                    AsignacionBienMueble.BienMueble.Nombre = solicitudAsignacionVM.ListaBienes.Where(w => w.IdBienMueble == AsignacionBienMueble.IdBienMueble).Select(x => x.Nombre).FirstOrDefault();

                    SolicitudAsignacion.AsignacionBienMueble.Add(AsignacionBienMueble);
                }

                SetCache<ICollection<AsignacionBienMuebleVob>>(SolicitudAsignacion.AsignacionBienMueble);

                solicitudAsignacionVM.ListaTrabajadores = trabajadorNegocio.Select(SolicitudAsignacion.IdArea); //new List<UsuarioTrabajadorVob>();
                solicitudAsignacionVM.SolicitudAsignacion = SolicitudAsignacion;
                solicitudAsignacionVM.AsignacionBienMueble = AsignacionBienMueble;

                return View(solicitudAsignacionVM);
                //}
                //else
                //{
                //    return View(solicitudAsignacionVM);
                //}
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorSistema", "Error", new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Guardar")]
        public ActionResult Guardar(SolicitudAsignacionBienMuebleVob SolicitudAsignacion, int id = 0)
        {
            try
            {
                var solicitudNegocio = new GCPSolicitudAsignacionBienMuebleNegocio();
                var asignacionBienNegocio = new GCPAsignacionBienMuebleNegocio();
                int nroSolicitud = id;

                ICollection<AsignacionBienMuebleVob> asignaciones = GetCache<ICollection<AsignacionBienMuebleVob>>(SolicitudAsignacion.AsignacionBienMueble);
                SolicitudAsignacion.AsignacionBienMueble = asignaciones;

                int codigo;

                if (id > 0)
                {
                    SolicitudAsignacion.Estado = new EstadoVob();
                    SolicitudAsignacion.Estado.IdEstado = 1;
                    SolicitudAsignacion.IdEstado = 1; // Registrado

                    SolicitudAsignacion.Area = new AreaVob();
                    SolicitudAsignacion.Area.IdArea = SolicitudAsignacion.IdArea;

                    solicitudNegocio.Update(SolicitudAsignacion);
                    codigo = SolicitudAsignacion.IdSolicitudAsignacion;

                    // Elimino las asignaciones
                    asignacionBienNegocio.DeleteAll(codigo);
                }
                else
                    codigo = solicitudNegocio.Insert(SolicitudAsignacion);

                foreach (AsignacionBienMuebleVob a in asignaciones)
                    asignacionBienNegocio.Insert(a, codigo);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorSistema", "Error", new { mensaje = ex.Message });
            }
        }

        public ActionResult Anular(int id)
        {
            try
            {
                var solicitudNegocio = new GCPSolicitudAsignacionBienMuebleNegocio();
                solicitudNegocio.CambiarEstado(id, 6); // Anular: 6
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorSistema", "Error", new { mensaje = ex.Message });
            }
        }

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class MultipleButtonAttribute : ActionNameSelectorAttribute
        {
            public string Name { get; set; }
            public string Argument { get; set; }

            public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
            {
                var isValidName = false;
                var keyValue = string.Format("{0}:{1}", Name, Argument);
                var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);

                if (value != null)
                {
                    controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
                    isValidName = true;
                }

                return isValidName;
            }
        }

    }
}