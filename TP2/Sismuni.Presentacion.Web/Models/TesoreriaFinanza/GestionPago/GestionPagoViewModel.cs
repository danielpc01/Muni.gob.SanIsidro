using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sismuni.Dominio.Entidad.General;
using Sismuni.Dominio.Entidad.TesoreriaFinanza.GestionPago;
using Sismuni.Dominio.Entidad.ControlPatrimonial;
using System.Web.Mvc;
using System.ComponentModel;

namespace Sismuni.Presentacion.Web.Models.TesoreriaFinanza.GestionPago
{
    public class GestionPagoViewModel
    {
        public IList<SolicitudPagoServicioVob> ListaSolicitudes { get; set; }
        public IList<AreaVob> ListaAreas{ get; set; }
        public IList<UsuarioTrabajadorVob> ListaTrabajadores { get; set; }
        public PagoServicioVob PagoServicio { get; set; }
        public BindingList<SelectListItem> ListaEstados { get; set; }
        public SolicitudPagoServicioVob FiltroBusqueda { get; set; }
        public SolicitudPagoServicioVob SolicitudPagoServicio { get; set; }
        public BindingList<SelectListItem> ListaMonedas { get; set; }
        public BindingList<SelectListItem> ListaFormaPago { get; set; }
        public String tipoTransaccion { get; set; }

        public GestionPagoViewModel()
        {
            ListaSolicitudes = new List<SolicitudPagoServicioVob>();
            PagoServicio = new PagoServicioVob();
            ListaEstados = new BindingList<SelectListItem>();
            FiltroBusqueda = new SolicitudPagoServicioVob();
            ListaMonedas = new BindingList<SelectListItem>();
            //ListaFormaPago = new IList<FormaPago>();
        }

        public GestionPagoViewModel(SolicitudPagoServicioVob _FiltroBusqueda)
        {
            FiltroBusqueda = _FiltroBusqueda;
        }
    }
}