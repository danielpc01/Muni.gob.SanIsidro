using Sismuni.Dominio.Entidad.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.ControlPatrimonial
{
    public class UsuarioTrabajadorVob : BaseVob
    {
        public int IdUsuarioTrabajador { get; set; }
        public int IdArea { get; set; }
        public int IdCargo { get; set; }
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }

        public string NombreCompleto
        {
            get
            {
                return this.ApePaterno + " " + this.ApeMaterno + ", " + this.Nombre;
            }
        }
        public int IdDocumento { get; set; }
        public string NroDocumento { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public Nullable<System.DateTime> FechaCese { get; set; }
        public virtual EstadoVob Estado { get; set; }
        public virtual AreaVob Area { get; set; }
        public virtual CargoVob Cargo { get; set; }
    }
}
