using Sismuni.Dominio.Entidad.ControlPatrimonial;
using Sismuni.Infraestructura.Data.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.ControlPatrimonial
{
    public class GCPSolicitudAsignacionBienMueble : IGCPSolicitudAsignacionBienMueble
    {
        UPC_MUNIEntities context = new UPC_MUNIEntities();

        public SolicitudAsignacionBienMuebleVob Select(int nroSolicitud)
        {
            return SelectAll(nroSolicitud).FirstOrDefault();
        }

        public IList<SolicitudAsignacionBienMuebleVob> SelectAll(int nroSolicitud = -1)
        {
            var solicitud = from a in context.SolicitudAsignacionBienMueble
                            where nroSolicitud == -1 || a.NroSolicitudAsignacion == nroSolicitud
                            select new SolicitudAsignacionBienMuebleVob
                    {
                        IdSolicitudAsignacion = a.IdSolicitudAsignacion,
                        IdEstado = a.IdEstado,
                        NroSolicitudAsignacion = a.NroSolicitudAsignacion,
                        FechaSolicitudAsignacion = a.FechaSolicitudAsignacion,
                        IdArea = a.IdArea,
                        IdUsuarioTrabajador = a.IdUsuarioTrabajador,
                        UsuRegistro = a.UsuRegistro,
                        FechaRegistro = a.FechaRegistro,
                        UsuModifica = a.UsuModifica,
                        FechaModifica = a.FechaModifica,
                        Estado = new EstadoVob
                        {
                            IdEstado = a.Estado.IdEstado,
                            Descripcion = a.Estado.Descripcion,
                            Activo = a.Estado.Activo,
                            UsuRegistro = a.Estado.UsuRegistro,
                            FechaRegistro = a.Estado.FechaRegistro,
                            UsuModifica = a.Estado.UsuModifica,
                            FechaModifica = a.Estado.FechaModifica
                        },
                        AsignacionBienMueble = (from abm in a.AsignacionBienMueble
                                                select new AsignacionBienMuebleVob
                                                {
                                                    IdAsignacion = abm.IdAsignacion,
                                                    IdSolicitudAsignacion = abm.IdSolicitudAsignacion,
                                                    IdUsuarioTrabajador = abm.IdUsuarioTrabajador,
                                                    IdBienMueble = abm.IdBienMueble,
                                                    Cantidad = abm.Cantidad,
                                                    FechaAsignacion = abm.FechaAsignacion,
                                                    UsuRegistro = abm.UsuRegistro,
                                                    FechaRegistro = abm.FechaRegistro,
                                                    UsuModifica = abm.UsuModifica,
                                                    FechaModifica = abm.FechaModifica,
                                                    BienMueble = new BienMuebleVob
                                                    {
                                                        IdBienMueble = abm.IdBienMueble,
                                                        Nombre = abm.BienMueble.Nombre
                                                    }
                                                }).ToList()
                    };

            return solicitud.ToList();
        }

        public int Insert(SolicitudAsignacionBienMuebleVob solicitud, int idEstado)
        {
            SolicitudAsignacionBienMueble sol = new SolicitudAsignacionBienMueble();
            sol.IdEstado = idEstado;
                sol.IdArea = solicitud.IdArea;
                sol.NroSolicitudAsignacion = solicitud.NroSolicitudAsignacion;
                sol.FechaSolicitudAsignacion = DateTime.Now;
                sol.IdUsuarioTrabajador = solicitud.IdUsuarioTrabajador;
                sol.UsuRegistro = "ADMIN";
                sol.FechaRegistro = DateTime.Now;
            context.SolicitudAsignacionBienMueble.Add(sol);
            context.SaveChanges();

            return sol.IdSolicitudAsignacion;
        }

        public bool Update(SolicitudAsignacionBienMuebleVob solicitud)
        {

            var sol = (from c in context.SolicitudAsignacionBienMueble
                          where c.IdSolicitudAsignacion == solicitud.IdSolicitudAsignacion
                            select c).First();

            //SolicitudAsignacionBienMueble sol = new SolicitudAsignacionBienMueble();
            //sol.IdSolicitudAsignacion = solicitud.IdSolicitudAsignacion;
            sol.IdEstado = solicitud.IdEstado;
            sol.IdArea = solicitud.IdArea;
            //sol.NroSolicitudAsignacion = solicitud.NroSolicitudAsignacion;
            sol.IdUsuarioTrabajador = solicitud.IdUsuarioTrabajador;
            sol.UsuModifica = "ADMIN";
            sol.FechaModifica = DateTime.Now;
            //sol.Estado = new Estado();
            //sol.Estado.IdEstado = solicitud.Estado.IdEstado;
            //sol.Area = new Area();
            //sol.Area.IdArea = solicitud.Area.IdArea;

            context.SolicitudAsignacionBienMueble.Attach(sol);
            context.Entry(sol).State = EntityState.Modified;
            return (context.SaveChanges() != 0);
        }

        public void CambiarEstado(int idSolicitudAsignacion, int idEstado)
        {
            var SolicitudAsignacion = (from c in context.SolicitudAsignacionBienMueble
                                       where c.IdSolicitudAsignacion == idSolicitudAsignacion
                                       select c).First();

            SolicitudAsignacion.IdEstado = idEstado;

            context.SolicitudAsignacionBienMueble.Attach(SolicitudAsignacion);
            context.Entry(SolicitudAsignacion).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
