using Sismuni.Dominio.Entidad.TesoreriaFinanza.ReciboProvisional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.TesoreriaFinanza.ReciboProvisional
{
    public class RespuestaBusquedaRecibosProvVob
    {
        public List<ReciboProvisionalVob> listRecibosProvisional { get; set; }
        public int totalelementos { get; set; }
    }
}
