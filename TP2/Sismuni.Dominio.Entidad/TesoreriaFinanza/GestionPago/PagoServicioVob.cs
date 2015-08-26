using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.TesoreriaFinanza.GestionPago
{
    public class PagoServicioVob
    {
        public SolicitudPagoServicioVob SolicitudPagoServicio { get; set; }
        public long NumPago { get; set; }
        public Nullable<decimal> MontoPago { get; set; }
        public Nullable<System.DateTime> FechaPago { get; set; }

        public Nullable<long> CodFormaPago { get; set; }
        public string DescFormaPago { get; set; }
       
        public Nullable<long> CodTipoCambio { get; set; }
        public string DescTipoCambio { get; set; }

        public string CodMonedaPago { get; set; }
        public string DescMonedaPago { get; set; }

        public string CodEstadoPago { get; set; }
        public string DescEstadoPago { get; set; }

        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
    }
}
