using Sismuni.Infraestructura.Data.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sismuni.Dominio.Entidad.ControlPatrimonial;
using Sismuni.Infraestructura.Data.Repositorios.ControlPatrimonial;

namespace Sismuni.Dominio.Negocio.ControlPatrimonial
{
    public class GCPSolicitudAsignacionBienMuebleNegocio : IGCPSolicitudAsignacionBienMuebleNegocio
    {
        public SolicitudAsignacionBienMuebleVob Select(int nroSolicitud)
        {
            var solAsigBienMuebleRepositorio = new GCPSolicitudAsignacionBienMueble();
            return solAsigBienMuebleRepositorio.Select(nroSolicitud);
        }

        public IList<SolicitudAsignacionBienMuebleVob> SelectAll()
        {
            var solAsigBienMuebleRepositorio = new GCPSolicitudAsignacionBienMueble();
            return solAsigBienMuebleRepositorio.SelectAll();
        }

        public int Insert(SolicitudAsignacionBienMuebleVob solicitud)
        {
            var solAsigBienMuebleRepositorio = new GCPSolicitudAsignacionBienMueble();
            GCPAsignacionBienMuebleNegocio asigNegocio = new GCPAsignacionBienMuebleNegocio();
            int idEstado = 2; // Estado "Pendiente" por defecto 

            /*
             * GCP_RN16
             * Verifica que el usuario solicitante no tenga solicitudes pendientes
             * para el mismo producto, cantidad y Usuario Responsable
             */
            IList<AsignacionBienMuebleVob> asignaciones = asigNegocio.SelectAsignacionesPendientesXSolicitante(solicitud.IdUsuarioTrabajador);
            var cont = (from a in asignaciones
                        join s in solicitud.AsignacionBienMueble
                        on new { a.IdBienMueble, a.IdUsuarioTrabajador, a.Cantidad } equals new { s.IdBienMueble, s.IdUsuarioTrabajador, s.Cantidad }
                        select a).Count();

            if (cont > 0)
                idEstado = 4; // Rechazado

            return solAsigBienMuebleRepositorio.Insert(solicitud, idEstado);
        }

        public bool Update(SolicitudAsignacionBienMuebleVob solicitud)
        {
            var solAsigBienMuebleRepositorio = new GCPSolicitudAsignacionBienMueble();
            return solAsigBienMuebleRepositorio.Update(solicitud);
        }

        public void CambiarEstado(int idSolicitudAsignacion, int idEstado)
        {
            var solAsigBienMuebleRepositorio = new GCPSolicitudAsignacionBienMueble();
            solAsigBienMuebleRepositorio.CambiarEstado(idSolicitudAsignacion, idEstado);
        }
    }
}
