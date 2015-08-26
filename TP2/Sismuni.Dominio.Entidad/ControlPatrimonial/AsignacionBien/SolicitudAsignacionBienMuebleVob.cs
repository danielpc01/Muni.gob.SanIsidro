using Sismuni.Dominio.Entidad.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.ControlPatrimonial
{
    public class SolicitudAsignacionBienMuebleVob : BaseVob
    {
        public int IdSolicitudAsignacion { get; set; }
        public int IdEstado { get; set; }
        [Required(ErrorMessage="Se requiere el número de Solicitud")]
        public int NroSolicitudAsignacion { get; set; }
        public System.DateTime FechaSolicitudAsignacion { get; set; }
        public int IdArea { get; set; }
        public int IdUsuarioTrabajador { get; set; }

        public virtual EstadoVob Estado { get; set; }
        public virtual AreaVob Area { get; set; }
        public virtual ICollection<AsignacionBienMuebleVob> AsignacionBienMueble { get; set; }
    }
}
