using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.ControlPatrimonial
{
    public class BaseVob
    {
        public string UsuRegistro { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public string UsuModifica { get; set; }
        public Nullable<System.DateTime> FechaModifica { get; set; }

    }
}
