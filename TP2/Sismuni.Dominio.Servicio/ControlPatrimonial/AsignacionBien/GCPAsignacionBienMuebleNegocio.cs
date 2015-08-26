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
    public class GCPAsignacionBienMuebleNegocio : IGCPAsignacionBienMuebleNegocio
    {
        public IList<AsignacionBienMuebleVob> SelectAsignacionesPendientesXSolicitante(int idUsuarioTrabajador)
        {
            var asigBienMuebleRepositorio = new GCPAsignacionBienMueble();
            return asigBienMuebleRepositorio.SelectAsignacionesPendientesXSolicitante(idUsuarioTrabajador);
        }

        public bool Delete(AsignacionBienMuebleVob asignacion)
        {
            var asigBienMuebleRepositorio = new GCPAsignacionBienMueble();
            return asigBienMuebleRepositorio.Delete(asignacion);
        }

        public void DeleteAll(int idSolicitudAsignacion)
        {
            var asigBienMuebleRepositorio = new GCPAsignacionBienMueble();
            asigBienMuebleRepositorio.DeleteAll(idSolicitudAsignacion);
        }

        public int Insert(AsignacionBienMuebleVob asignacion, int idSolicitudAsignacion)
        {
            var asigBienMuebleRepositorio = new GCPAsignacionBienMueble();
            return asigBienMuebleRepositorio.Insert(asignacion, idSolicitudAsignacion);
        }
    }
}
