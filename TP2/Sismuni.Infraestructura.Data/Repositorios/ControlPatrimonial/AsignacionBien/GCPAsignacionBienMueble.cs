using Sismuni.Dominio.Entidad.ControlPatrimonial;
using Sismuni.Infraestructura.Data.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.ControlPatrimonial
{
    public class GCPAsignacionBienMueble : IGCPAsignacionBienMueble
    {
        UPC_MUNIEntities context = new UPC_MUNIEntities();

        public IList<AsignacionBienMuebleVob> SelectAsignacionesPendientesXSolicitante(int idUsuarioTrabajador)
        {
            return (from a in context.AsignacionBienMueble
                    join s in context.SolicitudAsignacionBienMueble
                        on a.IdSolicitudAsignacion equals s.IdSolicitudAsignacion
                    where s.IdUsuarioTrabajador == idUsuarioTrabajador && s.IdEstado == 2
                    select new AsignacionBienMuebleVob {
                        IdUsuarioTrabajador = a.IdUsuarioTrabajador,
                        IdBienMueble = a.IdBienMueble,
                        Cantidad = a.Cantidad
                    }).ToList();
        }

        public int Insert(AsignacionBienMuebleVob asignacion, int idSolicitudAsignacion)
        {
            context.AsignacionBienMueble.Add(new AsignacionBienMueble{
                IdSolicitudAsignacion = idSolicitudAsignacion,
                IdUsuarioTrabajador = asignacion.IdUsuarioTrabajador,
                IdBienMueble = asignacion.IdBienMueble,
                Cantidad = asignacion.Cantidad,
                FechaAsignacion = DateTime.Now,
                UsuRegistro = "ADMIN",
                FechaRegistro = DateTime.Now
            });
            return context.SaveChanges();
        }

        public void DeleteAll(int idSolicitudAsignacion)
        {
            foreach (var id in context.AsignacionBienMueble.Where(w => w.IdSolicitudAsignacion == idSolicitudAsignacion).Select(e => e.IdAsignacion))
            {
                var entity = new AsignacionBienMueble { IdAsignacion = id };
                context.AsignacionBienMueble.Attach(entity);
                context.AsignacionBienMueble.Remove(entity);
            }
            context.SaveChanges();
        }

        public bool Delete(AsignacionBienMuebleVob asignacion)
        {
            context.AsignacionBienMueble.Attach(new AsignacionBienMueble
            {
                IdSolicitudAsignacion = asignacion.IdSolicitudAsignacion,
                IdUsuarioTrabajador = asignacion.IdUsuarioTrabajador,
                IdBienMueble = asignacion.IdBienMueble,
                Cantidad = asignacion.Cantidad,
                FechaAsignacion = asignacion.FechaAsignacion,
                UsuRegistro = "ADMIN",
                FechaRegistro = asignacion.FechaRegistro
            });
            context.AsignacionBienMueble.Remove(new AsignacionBienMueble
            {
                IdSolicitudAsignacion = asignacion.IdSolicitudAsignacion,
                IdUsuarioTrabajador = asignacion.IdUsuarioTrabajador,
                IdBienMueble = asignacion.IdBienMueble,
                Cantidad = asignacion.Cantidad,
                FechaAsignacion = asignacion.FechaAsignacion,
                UsuRegistro = "ADMIN",
                FechaRegistro = asignacion.FechaRegistro
            });
            return (context.SaveChanges() != 0);
        }
    }
}
