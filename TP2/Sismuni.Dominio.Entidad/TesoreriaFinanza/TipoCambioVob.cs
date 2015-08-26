using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.TesoreriaFinanza
{
    public class TipoCambioVob
    {
        public long Codigo { get; set; }

        public string CodMoneda { get; set; }
        public string DescMoneda { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<decimal> Monto { get; set; }
    

    }
}
