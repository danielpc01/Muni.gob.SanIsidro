using Sismuni.Dominio.Entidad.General;
using Sismuni.Infraestructura.Data.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sismuni.Infraestructura.Data.Repositorios.General;

namespace Sismuni.Dominio.Negocio.General
{
    public class GCPAreaNegocio : IGCPAreaNegocio
    {
        public IList<AreaVob> SelectAll()
        {
            var areaRepositorio = new GCPArea();
            return areaRepositorio.SelectAll();
        }
    }
}
