using Sismuni.Dominio.Entidad.Transparencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.Transparencia.GestionExpediente
{
    public interface IGNTExpedienteRepositorio
    {
        List<ExpedienteVob> BuscarExpedientes();
        ExpedienteVob BuscarExpedienteporId(long id);
        int Agregar(ExpedienteVob expediente);
        int Modificar(ExpedienteVob expediente);
    }
}
