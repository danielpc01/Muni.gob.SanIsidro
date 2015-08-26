using Sismuni.Dominio.Entidad.ControlPatrimonial;
using Sismuni.Dominio.Entidad.General;
using Sismuni.Infraestructura.Data.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.ControlPatrimonial
{
    public class GCPUsuarioTrabajador : IGCPUsuarioTrabajador
    {
        UPC_MUNIEntities context = new UPC_MUNIEntities();

        public IList<UsuarioTrabajadorVob> Select(int idArea)
        {
            return (from a in context.UsuarioTrabajador
                    where a.Area.IdArea == idArea
                    select new UsuarioTrabajadorVob
                   {
                       IdUsuarioTrabajador = a.IdUsuarioTrabajador,
                       Nombre = a.Nombre,
                       ApePaterno = a.ApePaterno,
                       ApeMaterno = a.ApeMaterno,
                       IdDocumento = a.IdDocumento,
                       NroDocumento = a.NroDocumento,
                       FechaNacimiento = a.FechaNacimiento,
                       FechaIngreso = a.FechaIngreso,
                       FechaCese = a.FechaCese,
                       UsuRegistro = a.UsuRegistro,
                       FechaRegistro = a.FechaRegistro,
                       UsuModifica = a.UsuModifica,
                       FechaModifica = a.FechaModifica,
                       Area = new AreaVob
                       {
                           IdArea = a.Area.IdArea,
                           Nombre = a.Area.Nombre,
                           Activo = a.Area.Activo,
                           UsuRegistro = a.Area.UsuRegistro,
                           FechaRegistro = a.Area.FechaRegistro,
                           UsuModifica = a.Area.UsuModifica,
                           FechaModifica = a.Area.FechaModifica
                       },
                       Cargo = new CargoVob
                       {
                           IdCargo = a.Cargo.IdCargo,
                           Nombre = a.Cargo.Nombre,
                           Activo = a.Cargo.Activo,
                           UsuRegistro = a.Cargo.UsuRegistro,
                           FechaRegistro = a.Cargo.FechaRegistro,
                           UsuModifica = a.Cargo.UsuModifica,
                           FechaModifica = a.Cargo.FechaModifica
                       },
                       Estado = new EstadoVob
                       {
                           IdEstado = a.Estado.IdEstado,
                           Descripcion = a.Estado.Descripcion,
                           Activo = a.Estado.Activo,
                           UsuRegistro = a.Estado.UsuRegistro,
                           FechaRegistro = a.Estado.FechaRegistro,
                           UsuModifica = a.Estado.UsuModifica,
                           FechaModifica = a.Estado.FechaModifica
                       }
                   }).ToList();
        }


    }
}
