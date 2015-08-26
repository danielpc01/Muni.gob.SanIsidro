using Sismuni.Dominio.Entidad.ControlPatrimonial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Negocio.ControlPatrimonial
{
    public interface IGCPSolicitudAsignacionBienMuebleNegocio
    {
        SolicitudAsignacionBienMuebleVob Select(int nroSolicitud);
        IList<SolicitudAsignacionBienMuebleVob> SelectAll();
        int Insert(SolicitudAsignacionBienMuebleVob solicitud);
        bool Update(SolicitudAsignacionBienMuebleVob solicitud);
        void CambiarEstado(int idSolicitudAsignacion, int idEstado);
    }
}
