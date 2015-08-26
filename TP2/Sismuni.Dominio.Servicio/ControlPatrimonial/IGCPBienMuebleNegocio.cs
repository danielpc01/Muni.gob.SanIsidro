using Sismuni.Dominio.Entidad.ControlPatrimonial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Negocio.ControlPatrimonial
{
    public interface IGCPBienMuebleNegocio
    {
        IList<BienMuebleVob> SelectAll();
    }
}
