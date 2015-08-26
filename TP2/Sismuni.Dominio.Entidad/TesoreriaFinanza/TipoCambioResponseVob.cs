using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.TesoreriaFinanza
{
    public class TipoCambioResponseVob
    {
        public String CodResponse { get; set; }
        public TipoCambioVob Body { get; set; }
        public Nullable<decimal> MontoCalculado { get; set; }
    }
}
