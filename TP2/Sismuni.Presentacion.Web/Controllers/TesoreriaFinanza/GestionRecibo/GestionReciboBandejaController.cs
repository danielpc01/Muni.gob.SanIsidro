using Sismuni.Dominio.Entidad.General;
using Sismuni.Dominio.Entidad.Transparencia;
using Sismuni.Presentacion.Web.Models.General;
using Sismuni.Presentacion.Web.Helpers;
using Sismuni.Presentacion.Web.Helpers.Mvc;
using Sismuni.Presentacion.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sismuni.Presentacion.Web.Controllers.General;
using Sismuni.Dominio.Servicio.Transparencia;
using Sismuni.Dominio.Servicio.TesoreriaFinanza;
using Sismuni.Presentacion.Web.Models.TesoreriaFinanza.GestionRecibo;
using Sismuni.Dominio.Entidad.TesoreriaFinanza.ReciboProvisional;
using Sismuni.Presentacion.Web.Models.TesoreriaFinanza.GestionPago;
using Sismuni.Dominio.Negocio.General;
using Sismuni.Dominio.Servicio.Recursos;
using Sismuni.Presentacion.Web.Helpers.Extensiones;
using Sismuni.Dominio.Negocio.ControlPatrimonial;
namespace Sismuni.Presentacion.Web.Controllers.Transparencia.GestionExpediente
{
    public class GestionReciboBandejaController : BaseController
    {
        // GET: GestionExpedienteBandeja
        public ActionResult Index()
        {
            try
            {
                return RedirectToAction("Buscar", "GestionReciboBandeja", new {init="true"});
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorSistema", "Error", new { mensaje = ex.Message });
            }
        }
        public ActionResult Calificar(string submit1, string submit2, ReciboProvisionalVob reciboProvisional, int id = 0)
        {
            try
            {

                if (submit1 == "Grabar")
                {

                    if (reciboProvisional.Estado == "0006001")
                    {
                        reciboProvisional.MotivoRechazo = null;
                    }

                    var areaNegocio = new TFReciboProvisionalNegocio();

                     areaNegocio.ModificarReciboProvisional(reciboProvisional);

                     return RedirectToAction("Buscar", "GestionReciboBandeja", new { init = "true" });
                }
                else if (submit2 == "Cancelar")
                {
                    return RedirectToAction("Buscar", "GestionReciboBandeja", new { init = "true" });
                }
                else
                {
                    var multitablaNegocio = new MultitablaNegocio();
                    var reciboNegocio = new TFReciboProvisionalNegocio();
                    var view = new GestionReciboViewModel();

                    if (view.ListaEstados == null || view.ListaEstados.Count <= 0)
                    {
                        List<ElementoVob> listadoEstados = multitablaNegocio.BuscarElementos(GrupoTabla.EstadoReciboProvisional);
                        List<ElementoVob> listadoEstadosNew = new List<ElementoVob>();
                        ElementoVob inicial = new ElementoVob();
                        inicial.Valor = "-1";
                        inicial.Texto = "Seleccionar";
                        listadoEstadosNew.Add(inicial);

                        foreach(ElementoVob obj in listadoEstados){
                            if(!"Pendiente".Equals(obj.Texto)){
                                listadoEstadosNew.Add(obj);
                            }
                        }


                        view.ListaEstados = listadoEstadosNew.LlenarTT();
                    }


                    SolicitudBusquedaRecibosProvVob request = new SolicitudBusquedaRecibosProvVob();
                    request.ReciboProvisionalFilter = new ReciboProvisionalVob();
                    request.ReciboProvisionalFilter.NumeroRecibo = id;
                    RespuestaBusquedaRecibosProvVob respuesta = reciboNegocio.BuscarRecibosProvisionales(request);

                    view.reciboProvisional = respuesta.listRecibosProvisional[0];


                    return PartialView("FrmReciboProvisional", view);
                }
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorSistema", "Error", new { mensaje = ex.Message });
            }
        }
        public PartialViewResult Buscar(GestionReciboViewModel view = null, String init=null)
        {
            var reciboNegocio = new TFReciboProvisionalNegocio();
            var multitablaNegocio = new MultitablaNegocio();
            var usuarioNegocio = new GCPUsuarioTrabajadorNegocio();
            if (view == null) {
                view = new GestionReciboViewModel();
            }

            if (view.ListaEstados == null || view.ListaEstados.Count<=0)
            {
                List<ElementoVob> listadoEstados = multitablaNegocio.BuscarElementos(GrupoTabla.EstadoReciboProvisional);
                List<ElementoVob> listadoEstadosNew = new List<ElementoVob>();
                ElementoVob inicial = new ElementoVob();
                inicial.Valor = "-1";
                inicial.Texto = "Seleccionar";
                listadoEstadosNew.Add(inicial);
                
                foreach (ElementoVob obj in listadoEstados)
                {
                    listadoEstadosNew.Add(obj);
                }


                view.ListaEstados = listadoEstadosNew.LlenarTT();
            }

            if (view.ListaTrabajadores == null || view.ListaTrabajadores.Count <= 0) {
                view.ListaTrabajadores=usuarioNegocio.Select(4);
            }
            

            SolicitudBusquedaRecibosProvVob request= new SolicitudBusquedaRecibosProvVob();
            
            request.ReciboProvisionalFilter = view.FiltroBusqueda;
            if(init!=null && init.Equals("true")){
                request.ReciboProvisionalFilter.CodEstado = "0006003";
            }
            RespuestaBusquedaRecibosProvVob respuesta = reciboNegocio.BuscarRecibosProvisionales(request);
            view.ListaSolicitudes = respuesta.listRecibosProvisional;

            return PartialView("_Index", view);
        }



        public ActionResult EmpleadosLookup()
        {
            var usuarioNegocio = new GCPUsuarioTrabajadorNegocio();
            var trabajadores=usuarioNegocio.Select(3);
            return Json(trabajadores, JsonRequestBehavior.AllowGet);
        }
      /*  
        public PartialViewResult Buscar(int page = 1,
                                        string sort = "NUMEROEXPEDIENTE",
                                        string sortDir = "DESC",
                                        ExpedientePaginadoModelo tablaPaginado = null,
                                        string mensaje = null,
                                        bool back = false
                                        )
        {

          //  var nombre = tablaPaginado.Filtro.Expediente != null ? tablaPaginado.Filtro.Expediente.NumeroExpediente : 0;

            //Buscamos si existe un temp del back
            if (back) tablaPaginado = GetCache<ExpedientePaginadoModelo>(tablaPaginado);


            //Asignamos valores iniciales
            tablaPaginado = IniciarFiltro(tablaPaginado);

            //Construimos solicitud
            var solicitud = ConstruirSolicitud(page, sort, sortDir, tablaPaginado);

            //Invocamos al servicio

            var _expedientenegocio = new GNTExpedienteNegocio();

            var respuesta = _expedientenegocio.BuscarExpedientes(solicitud);



            //construimos modelo
            var model = ConstruirModeloPaginado(page, respuesta, tablaPaginado.Filtro);
            model.AsignarMensaje(mensaje);

            if (respuesta != null)
            {
                if (respuesta.totalelementos == 0)
                    model.AsignarMensaje(MensajeMvc.MensajeAdvertencia(Mensajes.Msj_NoSeEncontraronResultados));
            }


            //Guardamos el filtro en la cache de la sesión
            if (!back) SetCache<ExpedientePaginadoModelo>(tablaPaginado);


            //Retornamos vista con modelo
            return PartialView("_Index", model);
        }

        #region MÉTODOS - APOYO

        internal ExpedientePaginadoModelo ConstruirModeloPaginado(int pagina, RespuestaBusquedaExpedientesVob respuesta, ExpedienteFiltroModelo filtro)
        {
            return new ExpedientePaginadoModelo
            {
                Grid = new ExpedienteGridModelo(respuesta.listaexpedientes, Convert.ToInt32(Paginacion.TamanioPaginaMin), respuesta.totalelementos),
                Filtro = new ExpedienteFiltroModelo(filtro.Expediente)
            };
        }

        internal SolicitudBusquedaExpedientesVob ConstruirSolicitud(int pagina, string orden, string ordernDir, ExpedientePaginadoModelo expediente)
        {
            return new SolicitudBusquedaExpedientesVob
            {
                ExpedienteFilter = expediente.Filtro.Expediente,
                CriterioPaginar = new CriterioPaginarVob
                {
                    Tamanio = Convert.ToInt32(Paginacion.TamanioPaginaMin),
                    Pagina = pagina,
                    Orden = orden,
                    OrdenDir = ordernDir
                }
            };
        }

        internal ExpedientePaginadoModelo IniciarFiltro(ExpedientePaginadoModelo expedientePaginado)
        {
            if (expedientePaginado == null) expedientePaginado = new ExpedientePaginadoModelo();
            if (expedientePaginado.Filtro.Expediente == null) expedientePaginado.Filtro.Expediente = new ExpedienteVob();
            return expedientePaginado;
        }

        #endregion*/
    }
}