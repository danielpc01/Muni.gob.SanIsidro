using Sismuni.Dominio.Entidad.TesoreriaFinanza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Servicio.TesoreriaFinanza
{
    public interface ITFTipoCambioNegocio
    {
        List<TipoCambioVob> BuscarTipoCambio(TipoCambioVob filtroBusqueda);

    }
}
