using Sismuni.Dominio.Entidad.ControlPatrimonial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.General
{
    public class CargoVob : BaseVob
    {
        public int IdCargo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}
