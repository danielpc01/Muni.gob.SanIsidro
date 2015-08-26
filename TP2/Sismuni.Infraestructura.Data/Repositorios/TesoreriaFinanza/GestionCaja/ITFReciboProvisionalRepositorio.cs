using Sismuni.Dominio.Entidad.TesoreriaFinanza.ReciboProvisional;
using Sismuni.Dominio.Entidad.Transparencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.TesoreriaFinanza.GestionCaja
{
    public interface ITFReciboProvisionalRepositorio
    {
        List<ReciboProvisionalVob> BuscarRecibosProvisionales();
        int Modificar(ReciboProvisionalVob reciboProvisional);
    }
}
