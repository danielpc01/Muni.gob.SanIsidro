using Sismuni.Dominio.Entidad.ControlPatrimonial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Negocio.ControlPatrimonial
{
    public interface IGCPAsignacionBienMuebleNegocio
    {
        int Insert(AsignacionBienMuebleVob solicitud, int idSolicitudAsignacion);

        bool Delete(AsignacionBienMuebleVob solicitud);

        void DeleteAll(int idSolicitudAsignacion);

        IList<AsignacionBienMuebleVob> SelectAsignacionesPendientesXSolicitante(int idUsuarioTrabajador);
    }
}
