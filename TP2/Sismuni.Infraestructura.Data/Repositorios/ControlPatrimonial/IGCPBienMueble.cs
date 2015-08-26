using Sismuni.Dominio.Entidad.ControlPatrimonial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.ControlPatrimonial
{
    public interface IGCPBienMueble
    {
        IList<BienMuebleVob> SelectAll();
    }
}
