using Sismuni.Dominio.Entidad.TesoreriaFinanza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sismuni.Infraestructura.Data.Modelo;

namespace Sismuni.Infraestructura.Data.Repositorios.TesoreriaFinanza
{
   public class TFTipoCambioRepositorio : ITFTipoCambioRepositorio
    {
        public List<TipoCambioVob> BuscarTipoCambio() {
            using (var context = new UPC_MUNIEntities())
            {

                var consulta = from tc in context.TipoCambio
                               orderby tc.Fecha descending
                               select new TipoCambioVob
                               {
                               Codigo=tc.Codigo,
                               CodMoneda=tc.CodMoneda,
                               DescMoneda=tc.Multitabla.NombreValor,
                               Fecha=tc.Fecha,
                               Monto=tc.Monto
                               };

                return consulta.ToList();
            }
        }
    }
}
