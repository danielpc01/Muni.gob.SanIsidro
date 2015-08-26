using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.ControlPatrimonial
{
    public class EstadoVob : BaseVob
    {
        public int IdEstado { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
