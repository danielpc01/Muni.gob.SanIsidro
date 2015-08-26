using Sismuni.Dominio.Entidad.Transparencia;
using Sismuni.Infraestructura.Data.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.Transparencia.GestionExpediente
{
    public class GNTExpedienteRepositorio : IGNTExpedienteRepositorio
    {

        public List<ExpedienteVob> BuscarExpedientes()
        {

            using (var context = new UPC_MUNIEntities())
            {

                var consulta = from exp in context.Expediente
                               select new ExpedienteVob
                               {
                                   NumeroExpediente = exp.NumeroExpediente,
                                   Codigo_Expediente = exp.NumeroExpediente,
                                   NumeroSolicitud = exp.NumeroSolicitud,
                                   FechaExpediente = exp.FechaExpediente,
                                   Nombres_Solicitante = exp.SolicitudInformacionMunicipal.NombresSolicitante + " " + exp.SolicitudInformacionMunicipal.ApellidoPaternoSolicitante + " " + exp.SolicitudInformacionMunicipal.ApellidoMaternoSolicitante,
                                   Estado = exp.Estado,
                                   Tipo_Expediente = exp.Multitabla.NombreValor,
                                   Asunto = exp.Asunto
                               };

                return consulta.ToList();
            }


        }

        public ExpedienteVob BuscarExpedienteporId(long id)
        {
            using (var context = new UPC_MUNIEntities())
            {

                var consulta = from exp in context.Expediente
                               where exp.NumeroExpediente == id
                               select new ExpedienteVob
                               {
                                   NumeroExpediente = exp.NumeroExpediente,
                                   Codigo_Expediente = exp.NumeroExpediente,
                                   NumeroSolicitud = exp.NumeroSolicitud,
                                   FechaExpediente = exp.FechaExpediente,
                                   Nombres_Solicitante = exp.SolicitudInformacionMunicipal.NombresSolicitante + " " + exp.SolicitudInformacionMunicipal.ApellidoPaternoSolicitante + " " + exp.SolicitudInformacionMunicipal.ApellidoMaternoSolicitante,
                                   Estado = exp.Estado,
                                   Tipo_Expediente = exp.Tipo_Expediente,
                                   Asunto = exp.Asunto
                               };

                return consulta.FirstOrDefault();
            }

        }

        public int Agregar(ExpedienteVob expediente)
        {
            Expediente exp = new Expediente();

            DateTime fecha = new DateTime();
            fecha = DateTime.Today;

            using (var context = new UPC_MUNIEntities())
            {
                exp.FechaExpediente = DateTime.Now;
                exp.Asunto = expediente.Asunto;
                exp.Tipo_Expediente = expediente.Tipo_Expediente;
                exp.Estado = 1;
                context.Expediente.Add(exp);
                context.SaveChanges();

                return Convert.ToInt32(exp.NumeroExpediente);

            };

        }

        public int Modificar(ExpedienteVob expediente)
        {
            Expediente exp = new Expediente();

            DateTime fecha = new DateTime();
            fecha = DateTime.Today;

            using (var context = new UPC_MUNIEntities())
            {



                var expmodif = (from c in context.Expediente
                                where c.NumeroExpediente == expediente.NumeroExpediente
                                select c).First();



                expmodif.Tipo_Expediente = expediente.Tipo_Expediente;
                expmodif.Asunto = expediente.Asunto;
                // exp.FechaExpediente = fecha;
                //exp.NumeroExpediente = expediente.NumeroExpediente;
                expmodif.Estado = 1;
              //  context.Expediente.Add(exp);
                context.SaveChanges();

                return Convert.ToInt32(expediente.NumeroExpediente);

            };

        }


    }
}
