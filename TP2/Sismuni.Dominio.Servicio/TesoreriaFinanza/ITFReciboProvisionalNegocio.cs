using Sismuni.Dominio.Entidad.TesoreriaFinanza.ReciboProvisional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Servicio.TesoreriaFinanza
{
    public interface ITFReciboProvisionalNegocio
    {
        RespuestaBusquedaRecibosProvVob BuscarRecibosProvisionales(SolicitudBusquedaRecibosProvVob solicitud);
        int ModificarReciboProvisional(ReciboProvisionalVob registro);

    }
}
