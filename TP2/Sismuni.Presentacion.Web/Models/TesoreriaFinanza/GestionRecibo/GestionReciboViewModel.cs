using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sismuni.Dominio.Entidad.General;
using Sismuni.Dominio.Entidad.TesoreriaFinanza.ReciboProvisional;
using Sismuni.Dominio.Entidad.ControlPatrimonial;
using System.ComponentModel;
using System.Web;
using System.Web.Mvc;

namespace Sismuni.Presentacion.Web.Models.TesoreriaFinanza.GestionRecibo
{
    public class GestionReciboViewModel
    {
        public IList<ReciboProvisionalVob> ListaSolicitudes { get; set; }
        public IList<AreaVob> ListaAreas{ get; set; }
        public IList<UsuarioTrabajadorVob> ListaTrabajadores { get; set; }
        public ReciboProvisionalVob reciboProvisional { get; set; }
        public ReciboProvisionalVob FiltroBusqueda { get; set; }
        
        public BindingList<SelectListItem> ListaEstados { get; set; }

        public GestionReciboViewModel()
        {
            ListaSolicitudes = new List<ReciboProvisionalVob>();
            reciboProvisional = new ReciboProvisionalVob();
            FiltroBusqueda = new ReciboProvisionalVob();
            ListaEstados = new BindingList<SelectListItem>();
            ListaTrabajadores = new List<UsuarioTrabajadorVob>(); 
        }


        public GestionReciboViewModel(ReciboProvisionalVob _FiltroBusqueda)
        {
            FiltroBusqueda = _FiltroBusqueda;
        }
    }
}