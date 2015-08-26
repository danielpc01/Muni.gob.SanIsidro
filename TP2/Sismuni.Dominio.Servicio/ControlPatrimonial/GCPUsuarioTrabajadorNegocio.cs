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
    public class GCPUsuarioTrabajadorNegocio : IGCPUsuarioTrabajadorNegocio
    {
        public IList<UsuarioTrabajadorVob> Select(int idArea)
        {
            var usuTrabajadorRepositorio = new GCPUsuarioTrabajador();
            return usuTrabajadorRepositorio.Select(idArea);
        }
    }
}
