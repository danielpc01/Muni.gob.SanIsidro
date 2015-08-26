using Sismuni.Dominio.Entidad.TesoreriaFinanza.GestionPago;
using Sismuni.Dominio.Entidad.Transparencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.TesoreriaFinanza.GestionPago
{
    public interface ITFPagoServicioRepositorio
    {
        List<SolicitudPagoServicioVob> BuscarSolicitudesPago();
        int Agregar(PagoServicioVob pagoServicio);
        int ModificarEstadoSolicitud(SolicitudPagoServicioVob registro);
    }
}
