using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.ControlPatrimonial
{
    public class BienMuebleVob : BaseVob
    {
        public int IdBienMueble { get; set; }
        public int IdEstado { get; set; }
        public string Nombre { get; set; }
        public virtual EstadoVob Estado { get; set; }
    }
}
