using Sismuni.Dominio.Entidad.General;
using Sismuni.Infraestructura.Data.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.General
{
    public class GCPArea : IGCPArea
    {
        UPC_MUNIEntities context = new UPC_MUNIEntities();

        public IList<AreaVob> SelectAll()
        {
            return (from a in context.Area
                   select new AreaVob
                   {
                       IdArea = a.IdArea,
                       Nombre = a.Nombre,
                       Activo = a.Activo,
                       UsuRegistro = a.UsuRegistro,
                       FechaRegistro = a.FechaRegistro,
                       UsuModifica = a.UsuModifica,
                       FechaModifica = a.FechaModifica
                   }).ToList();
        }


    }
}
