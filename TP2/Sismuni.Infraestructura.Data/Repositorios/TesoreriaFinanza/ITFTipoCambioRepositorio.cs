using Sismuni.Dominio.Entidad.TesoreriaFinanza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.TesoreriaFinanza
{
    public interface ITFTipoCambioRepositorio
    {
         List<TipoCambioVob> BuscarTipoCambio();

    }
}
