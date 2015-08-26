using Sismuni.Dominio.Entidad.Transparencia.GestionExpediente;
using Sismuni.Dominio.Servicio.Transparencia;
using Sismuni.Presentacion.Web.Controllers.General;
using Sismuni.Presentacion.Web.Helpers.Mvc;
using Sismuni.Presentacion.Web.Models.TesoreriaFinanza.GestionPago;
using Sismuni.Presentacion.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sismuni.Presentacion.Web.Controllers.TesoreriaFinanza.GestionPago
{
    public class GestionPagoController : BaseController
    {
        // GET: GestionExpediente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Editor(int? id, string mensaje = null)
        {

            //try
            //{
            //    var _expedientenegocio = new GNTExpedienteNegocio();

            //    var respuesta = _expedientenegocio.ObtenerEditor(id);

            //    var modelo = new ExpedienteEditorModelo(respuesta.Expediente,respuesta.Tipo_Expedientes);

            //    modelo.AsignarMensaje(mensaje);

            //    return View("_Editor", modelo);

            //}
            //catch (Exception ex)
            //{
            return RedirectToAction("ErrorSistema", "Error", new { mensaje = "texto2" });
            //}


        }

        //public ActionResult Agregar(ExpedienteEditorModelo editor)
        //{
        //    // Generando solicitud
        //    var solicitud = new RegistrarExpedienteVob
        //    {
        //        Expediente = editor.Expediente,
        //    };

        //    try
        //    {

        //        var _expedientenegocio = new GNTExpedienteNegocio();
        //        // Agregando nuevo 
        //        var id = _expedientenegocio.Agregar(solicitud);
        //        //EncuestaUsuarioPaginadoModelo model = new EncuestaUsuarioPaginadoModelo();
        //        //model.Filtro.EncuestaUsuario.IdEncuesta = id;
        //        // Generando el mensaje de salida
        //        var mensaje = MensajeMvc.MensajeSatisfactorio(string.Format(Mensajes.MsjeExpedienteRegistrado,id));

        //        //Redireccionando a la bandeja de Contrato
        //        return RedirectToAction("Buscar", "GestionExpedienteBandeja", new { mensaje = mensaje });
        //        //  return RedirectToAction("Editor", "GestionExpediente", new { id = id, mensaje = mensaje });
        //    }
        //    catch (Exception ex)
        //    {
        //        return RedirectToAction("ErrorSistema", "Error", new { mensaje = ex.Message });
        //    }
        //}

        //public ActionResult Modificar(ExpedienteEditorModelo editor)
        //{
        //    //// Generando solicitud
        //    //var solicitud = new RegistrarExpedienteVob
        //    //{
        //    //    Expediente = editor.Expediente,
        //    //};

        //    //try
        //    //{

        //    //    var _expedientenegocio = new GNTExpedienteNegocio();
        //    //    // Agregando nuevo 
        //    //    var id = _expedientenegocio.Modificar(solicitud);
        //    //    //EncuestaUsuarioPaginadoModelo model = new EncuestaUsuarioPaginadoModelo();
        //    //    //model.Filtro.EncuestaUsuario.IdEncuesta = id;
        //    //    // Generando el mensaje de salida
        //    //    var mensaje = MensajeMvc.MensajeSatisfactorio(string.Format(Mensajes.MsjeExpedienteModificado, id));

        //    //    //Redireccionando a la bandeja de Contrato
        //    //    return RedirectToAction("Buscar", "GestionExpedienteBandeja", new { mensaje = mensaje });
        //    //    //  return RedirectToAction("Editor", "GestionExpediente", new { id = id, mensaje = mensaje });
        //    //}
        //    //catch (Exception ex)
        //    //{
        //        return RedirectToAction("ErrorSistema", "Error", new { mensaje = ex.Message });
        //    //}
        //}

    }
}