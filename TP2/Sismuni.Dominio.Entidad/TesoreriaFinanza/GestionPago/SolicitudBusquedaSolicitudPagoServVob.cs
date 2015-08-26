using Sismuni.Dominio.Entidad.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.TesoreriaFinanza.GestionPago
{
    public class SolicitudBusquedaSolicitudPagoServVob
    {
        public SolicitudPagoServicioVob SolicitudPagoServFilter { get; set; }
        public CriterioPaginarVob CriterioPaginar { get; set; }
    }
}
