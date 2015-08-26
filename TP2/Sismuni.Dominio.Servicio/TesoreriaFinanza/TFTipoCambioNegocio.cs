using Sismuni.Dominio.Entidad.TesoreriaFinanza;
using Sismuni.Infraestructura.Data.Repositorios.TesoreriaFinanza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Servicio.TesoreriaFinanza
{
    public class TFTipoCambioNegocio : ITFTipoCambioNegocio
    {
        public List<TipoCambioVob> BuscarTipoCambio(TipoCambioVob filtroBusq)
        {
            var tipoCambioRepo = new TFTipoCambioRepositorio();

            List<TipoCambioVob> listaTipoCambio = tipoCambioRepo.BuscarTipoCambio();

            if (filtroBusq != null)
            {
                if (filtroBusq.CodMoneda != null && !"".Equals(filtroBusq.CodMoneda.Trim())) {
                    listaTipoCambio = listaTipoCambio.Where(x => x.CodMoneda == filtroBusq.CodMoneda).ToList();
                }
                
            }

            return listaTipoCambio;
        }
    }

   


}
