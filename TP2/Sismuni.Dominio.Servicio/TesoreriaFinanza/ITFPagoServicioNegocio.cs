using Sismuni.Dominio.Entidad.TesoreriaFinanza.GestionPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Servicio.TesoreriaFinanza
{
    public interface ITFPagoServicioNegocio
    {
        RespuestaBusquedaSolicitudPagoServVob BuscarSolicitudesPagoSericio(SolicitudBusquedaSolicitudPagoServVob solicitud);
        int AgregarPagoServicio(PagoServicioVob registro);
        int ModificarEstadoSolicitudPagoServicio(SolicitudPagoServicioVob registro);
        List<FormaPagoVob> listaFormaPago();

    }
}
