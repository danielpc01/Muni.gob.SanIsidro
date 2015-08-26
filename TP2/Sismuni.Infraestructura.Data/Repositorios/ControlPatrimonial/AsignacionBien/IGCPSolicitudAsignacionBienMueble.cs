using Sismuni.Dominio.Entidad.ControlPatrimonial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.ControlPatrimonial
{
    public interface IGCPSolicitudAsignacionBienMueble
    {
        SolicitudAsignacionBienMuebleVob Select(int nroSolicitud);
        IList<SolicitudAsignacionBienMuebleVob> SelectAll(int nroSolicitud = -1);
        int Insert(SolicitudAsignacionBienMuebleVob solicitud, int idEstado);
        bool Update(SolicitudAsignacionBienMuebleVob solicitud);
        void CambiarEstado(int idSolicitudAsignacion, int idEstado);
    }
}
