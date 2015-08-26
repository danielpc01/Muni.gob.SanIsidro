using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Entidad.TesoreriaFinanza.GestionPago
{
    public class RespuestaBusquedaSolicitudPagoServVob
    {
        public List<SolicitudPagoServicioVob> listaSolicitudPagoServicio { get; set; }
        public int totalElementos { get; set; }
    }
}
