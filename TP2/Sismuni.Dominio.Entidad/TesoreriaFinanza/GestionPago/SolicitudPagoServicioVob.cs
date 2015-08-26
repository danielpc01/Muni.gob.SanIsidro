using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.TesoreriaFinanza.GestionPago
{
    public class SolicitudPagoServicioVob
    {
        public long NumSolicitudPago { get; set; }
        public Nullable<System.DateTime> FechaSolicitud { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public string Motivo { get; set; }

        public string FechaCorta { get; set; }
        public string Hora { get; set; }

        public Nullable<long> CodContribuyente { get; set; }
        public string NombContribuyente { get; set; }
        public Nullable<long> CodConceptoPago { get; set; }
        public string DescConceptoPago { get; set; }
        public string CodEstadoSolicitud { get; set; }
        public string DescEstadoSolicitud { get; set; }
        public string DNI { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public string CodMoneda { get; set; }
        public string DesMoneda { get; set; }
        public long CodForPago { get; set; }
        public string DesForPago { get; set; }

        public Nullable<long> CodTipoCambio { get; set; }
        public Nullable<decimal> MontoTipoCambio { get; set; }
    }
}
