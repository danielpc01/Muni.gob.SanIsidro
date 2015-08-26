using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.TesoreriaFinanza.ReciboProvisional
{
    public class ReciboProvisionalVob
    {
        public long NumeroRecibo { get; set; }
        public Nullable<System.DateTime> FechaRecibo { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public string Concepto { get; set; }
        public string Estado { get; set; }
        public string CodEstado { get; set; }
        public string Motivo { get; set; }
        public string MotivoRechazo { get; set; }

        public Nullable<int> CodEmpleado { get; set; }
        public string DescEmpleado { get; set; }

        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
    }
}
