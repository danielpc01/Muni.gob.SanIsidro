using Sismuni.Dominio.Entidad.ControlPatrimonial;
using Sismuni.Infraestructura.Data.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.ControlPatrimonial
{
    public class GCPBienMueble : IGCPBienMueble
    {
        UPC_MUNIEntities context = new UPC_MUNIEntities();

        public IList<BienMuebleVob> SelectAll()
        {
            return (from a in context.BienMueble
                    select new BienMuebleVob
                    {
                        IdBienMueble = a.IdBienMueble,
                        Nombre = a.Nombre,
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
                        }
                    }).ToList();
        }


    }
}
