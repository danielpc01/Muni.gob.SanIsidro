using Sismuni.Dominio.Entidad.General;
using Sismuni.Dominio.Entidad.TesoreriaFinanza.ReciboProvisional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.TesoreriaFinanza.ReciboProvisional
{
    public class SolicitudBusquedaRecibosProvVob
    {
        public ReciboProvisionalVob ReciboProvisionalFilter { get; set; }
        public CriterioPaginarVob CriterioPaginar { get; set; }
    }
}
