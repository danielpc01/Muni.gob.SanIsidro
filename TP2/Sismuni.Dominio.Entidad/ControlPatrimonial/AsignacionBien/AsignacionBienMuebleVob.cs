using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.ControlPatrimonial
{
    public class AsignacionBienMuebleVob : BaseVob
    {
        public int IdAsignacion { get; set; }
        public int IdSolicitudAsignacion { get; set; }
        public int IdUsuarioTrabajador { get; set; }
        public int IdBienMueble { get; set; }
        public int Cantidad { get; set; }
        public System.DateTime FechaAsignacion { get; set; }
        public virtual BienMuebleVob BienMueble { get; set; }
        public virtual UsuarioTrabajadorVob UsuarioTrabajador { get; set; }
    }
}
