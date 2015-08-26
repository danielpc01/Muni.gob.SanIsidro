using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sismuni.Dominio.Entidad.ControlPatrimonial;
using Sismuni.Dominio.Entidad.General;

namespace Sismuni.Presentacion.Web.Models.ControlPatrimonial.AsignacionBien
{
    public class SolicitudAsignacionBienViewModel
    {
        public AsignacionBienMuebleVob AsignacionBienMueble { get; set; }
        public SolicitudAsignacionBienMuebleVob SolicitudAsignacion { get; set; }
        public IList<SolicitudAsignacionBienMuebleVob> ListaSolicitudes { get; set; }
        public IList<AreaVob> ListaAreas{ get; set; }
        public IList<UsuarioTrabajadorVob> ListaTrabajadores { get; set; }
        public IList<BienMuebleVob> ListaBienes { get; set; }

        public SolicitudAsignacionBienViewModel()
        {
            ListaSolicitudes = new List<SolicitudAsignacionBienMuebleVob>();
        }
    }
}