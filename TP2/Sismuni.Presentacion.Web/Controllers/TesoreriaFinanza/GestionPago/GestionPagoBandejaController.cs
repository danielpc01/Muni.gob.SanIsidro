using Sismuni.Dominio.Entidad.General;
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
using Sismuni.Dominio.Servicio.TesoreriaFinanza;
using Sismuni.Presentacion.Web.Models.TesoreriaFinanza.GestionPago;
using Sismuni.Dominio.Entidad.TesoreriaFinanza.GestionPago;
using Sismuni.Dominio.Negocio.General;
using Sismuni.Dominio.Servicio.Recursos;
using Sismuni.Presentacion.Web.Helpers.Extensiones;
using Sismuni.Dominio.Entidad.TesoreriaFinanza;

namespace Sismuni.Presentacion.Web.Controllers.TesoreriaFinanza.GestionPago
{
    public class GestionPagoBandejaController : BaseController
    {
        // GET: GestionExpedienteBandeja
        public ActionResult Index()
        {
            try
            {
                return RedirectToAction("Buscar", "GestionPagoBandeja");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorSistema", "Error", new { mensaje = ex.Message });
            }
        }

        public PartialViewResult Buscar(GestionPagoViewModel view = null, String init = null)
        {

            var listaPagos = new TFPagoServicioNegocio();
            var multitablaNegocio = new MultitablaNegocio();

            if (view == null)
            {
                view = new GestionPagoViewModel();
            }

            if (view.ListaEstados == null || view.ListaEstados.Count <= 0)
            {
                List<ElementoVob> listadoEstados = multitablaNegocio.BuscarElementos(GrupoTabla.EstadoSolicitudPagoServicio);
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

            SolicitudBusquedaSolicitudPagoServVob request = new SolicitudBusquedaSolicitudPagoServVob();
            request.SolicitudPagoServFilter = view.FiltroBusqueda;
            if (init != null && init.Equals("true"))
            {
                request.SolicitudPagoServFilter.CodEstadoSolicitud = "0010001";
            }

            RespuestaBusquedaSolicitudPagoServVob respuesta = listaPagos.BuscarSolicitudesPagoSericio(request);

            //var GestionPagoVM = new GestionPagoViewModel();
            view.ListaSolicitudes = respuesta.listaSolicitudPagoServicio;

            return PartialView("_Index", view);
        }

        //public ActionResult Calificar(string submit1, string submit2, ReciboProvisionalVob reciboProvisional, int id = 0)
        public ActionResult Pagar(string submit1, string submit2, string submit3, SolicitudPagoServicioVob SolicitudPagoServicio, string SolicitudPagoServicio_Monto, int id = 0, String tipoTran=null)
        {
            try
            {

                if (submit1 == "Pagar")
                {

                    //if (SolicitudPagoServicio.c == "0006001")
                    //{
                    //    SolicitudPagoServicio. = null;
                    //}

                    //var areaNegocio = new TFReciboProvisionalNegocio();

                    //areaNegocio.ModificarReciboProvisional(reciboProvisional);

                    var PagoServicios = new TFPagoServicioNegocio();
                    PagoServicioVob _PagoServicioVob = new PagoServicioVob();
                    _PagoServicioVob.FechaPago = DateTime.Now;
                    _PagoServicioVob.DescMonedaPago = SolicitudPagoServicio.DesMoneda;
                    _PagoServicioVob.DescFormaPago = SolicitudPagoServicio.DesForPago;
                    _PagoServicioVob.MontoPago = SolicitudPagoServicio.Monto;
                    _PagoServicioVob.CodEstadoPago = "0011001";
                    _PagoServicioVob.CodFormaPago = SolicitudPagoServicio.CodForPago;
                    _PagoServicioVob.CodMonedaPago = SolicitudPagoServicio.CodMoneda;
                    _PagoServicioVob.CodTipoCambio = SolicitudPagoServicio.CodTipoCambio;
                    _PagoServicioVob.SolicitudPagoServicio = SolicitudPagoServicio;
                    _PagoServicioVob.SolicitudPagoServicio.CodEstadoSolicitud = "0010002";

                    PagoServicios.AgregarPagoServicio(_PagoServicioVob);
                    //"Pagar", new { id = item.NumSolicitudPago })

                   // return RedirectToAction("Buscar", "GestionPagoBandeja", new { init = "true" });
                    return RedirectToAction("Pagar", "GestionPagoBandeja", new { tipoTran="1" });
                }
                else if (submit2 == "Anular")
                {
                    var pagoServiciosNego = new TFPagoServicioNegocio();
                    SolicitudPagoServicio.CodEstadoSolicitud = "0010003";
                    pagoServiciosNego.ModificarEstadoSolicitudPagoServicio(SolicitudPagoServicio);

                    //return RedirectToAction("Buscar", "GestionPagoBandeja", new { init = "true" });
                    return RedirectToAction("Pagar", "GestionPagoBandeja", new { tipoTran = "2" });
                }
                else if (submit3 == "Cancelar")
                {
                    return RedirectToAction("Buscar", "GestionPagoBandeja", new { init = "true" });
                }
                else
                {

                    var multitablaNegocio = new MultitablaNegocio();
                    var listaPagos = new TFPagoServicioNegocio();
                    var view = new GestionPagoViewModel();
                    view.tipoTransaccion = tipoTran;
                    if (view.ListaEstados == null || view.ListaEstados.Count <= 0)
                    {
                        List<ElementoVob> listadoEstados = multitablaNegocio.BuscarElementos(GrupoTabla.EstadoReciboProvisional);
                        List<ElementoVob> listadoEstadosNew = new List<ElementoVob>();
                        ElementoVob inicial = new ElementoVob();
                        inicial.Valor = "-1";
                        inicial.Texto = "Seleccionar";
                        listadoEstadosNew.Add(inicial);

                        foreach (ElementoVob obj in listadoEstados)
                        {
                            if (!"Pendiente".Equals(obj.Texto))
                            {
                                listadoEstadosNew.Add(obj);
                            }
                        }


                        view.ListaEstados = listadoEstadosNew.LlenarTT();
                    }

                    if (view.ListaMonedas == null || view.ListaMonedas.Count <= 0)
                    {
                        List<ElementoVob> listaMonedas = multitablaNegocio.BuscarElementos(GrupoTabla.TipoMoneda);
                        List<ElementoVob> listaMonedasNew = new List<ElementoVob>();
                        ElementoVob inicial = new ElementoVob();
                        inicial.Valor = "-1";
                        inicial.Texto = "Seleccionar";
                        listaMonedasNew.Add(inicial);

                        foreach (ElementoVob obj in listaMonedas)
                        {
                            if (!"Pendiente".Equals(obj.Texto))
                            {
                                listaMonedasNew.Add(obj);
                            }
                        }


                        view.ListaMonedas = listaMonedasNew.LlenarTT();
                    }

                    if (view.ListaFormaPago == null || view.ListaFormaPago.Count <= 0)
                    {
                        List<FormaPagoVob> listaFormaPago = listaPagos.listaFormaPago();
                        List<ElementoVob> listaFormaPagoNew = new List<ElementoVob>();
                        ElementoVob inicial = new ElementoVob();
                        inicial.Valor = "-1";
                        inicial.Texto = "Seleccionar";
                        listaFormaPagoNew.Add(inicial);

                        foreach (FormaPagoVob obj in listaFormaPago)
                        {
                            ElementoVob elemento = new ElementoVob();
                            elemento.Valor = obj.Codigo.ToString();
                            elemento.Texto = obj.Descripcion;
                            listaFormaPagoNew.Add(elemento);
                        }


                        view.ListaFormaPago = listaFormaPagoNew.LlenarTT();
                    }

                    SolicitudBusquedaSolicitudPagoServVob request = new SolicitudBusquedaSolicitudPagoServVob();
                    request.SolicitudPagoServFilter = new SolicitudPagoServicioVob();
                    request.SolicitudPagoServFilter.NumSolicitudPago = id;
                    RespuestaBusquedaSolicitudPagoServVob respuesta = listaPagos.BuscarSolicitudesPagoSericio(request);

                    view.SolicitudPagoServicio = respuesta.listaSolicitudPagoServicio[0];
                    view.SolicitudPagoServicio.FechaCorta = DateTime.Now.ToString("dd/MM/yyyy");
                    view.SolicitudPagoServicio.Hora = DateTime.Now.ToString("hh:mm:ss");
                    


                    return PartialView("FrmPago", view);
                }

            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorSistema", "Error", new { mensaje = ex.Message });
            }
        }

        public ActionResult GetTipoCambio(string CodMoneda = null, Nullable<decimal> monto = null)
        {
            var response = new TipoCambioResponseVob();
            var tipoCambioRepo = new TFTipoCambioNegocio();
            TipoCambioVob filtroBusq = new TipoCambioVob();
            filtroBusq.CodMoneda = CodMoneda;
            List<TipoCambioVob> listaTipoCambio = tipoCambioRepo.BuscarTipoCambio(filtroBusq);
            if (listaTipoCambio != null && listaTipoCambio.Count > 0)
            {
                response.CodResponse = "1";
                response.Body = listaTipoCambio.First();
                var montoTipoCamb = response.Body.Monto;
                if (monto != null && (montoTipoCamb != null && montoTipoCamb > 0))
                {

                    decimal nuevoMonto = (decimal)(monto / montoTipoCamb);

                    nuevoMonto = decimal.Round(nuevoMonto, 2);

                    response.MontoCalculado = nuevoMonto;
                }

         //       return Json(tipoCambio); //return PartialView(tipoCambio);//
            }
            else {
           //     return Json("No existe"); //return PartialView("No existe"); //
                response.CodResponse = "0";
            }
            return Json(response);
            
        }
    }
}