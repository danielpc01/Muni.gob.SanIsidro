using Sismuni.Dominio.Entidad.TesoreriaFinanza.ReciboProvisional;
//using Sismuni.Dominio.Entidad.Transparencia;
//using Sismuni.Dominio.Entidad.Transparencia.GestionExpediente;
//using Sismuni.Dominio.Servicio.TesoreriaFinanza;
using Sismuni.Infraestructura.Data.Repositorios.TesoreriaFinanza.GestionCaja;
//using Sismuni.Infraestructura.Data.Repositorios.Transparencia.GestionExpediente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Servicio.TesoreriaFinanza
{
    public class TFReciboProvisionalNegocio : ITFReciboProvisionalNegocio
    {
        public RespuestaBusquedaRecibosProvVob BuscarRecibosProvisionales(SolicitudBusquedaRecibosProvVob filtroBusq)
        {
            List<ReciboProvisionalVob> lista = new List<ReciboProvisionalVob>();
            var expedienterepositorio = new TFReciboProvisionalRepositorio();

            lista = expedienterepositorio.BuscarRecibosProvisionales();

            lista = lista.Where(x => x.NumeroRecibo > 0).ToList();

            if (filtroBusq.ReciboProvisionalFilter != null) {
                if (filtroBusq.ReciboProvisionalFilter.NumeroRecibo != null)
                {

                    if (filtroBusq.ReciboProvisionalFilter.NumeroRecibo > 0)
                    {
                        lista = lista.Where(x => x.NumeroRecibo == filtroBusq.ReciboProvisionalFilter.NumeroRecibo).ToList();
                    }

                    /*else if(solicitud.ReciboProvisionalFilter.CodEstado!=null){
                        lista = lista.Where(x => x.CodEstado == solicitud.ReciboProvisionalFilter.CodEstado).ToList();
                    }*/
                }

                if (filtroBusq.ReciboProvisionalFilter.CodEstado != null && !filtroBusq.ReciboProvisionalFilter.CodEstado.Equals("-1") )
                {
                    lista = lista.Where(x => x.CodEstado  == filtroBusq.ReciboProvisionalFilter.CodEstado).ToList();
                }

                if (filtroBusq.ReciboProvisionalFilter.FechaInicio != null)
                {
                    System.DateTime dateIni = (System.DateTime)filtroBusq.ReciboProvisionalFilter.FechaInicio;
                    System.DateTime dateIniNew = new System.DateTime(dateIni.Year, dateIni.Month, dateIni.Day, 0, 0, 0);
                    

                    lista = lista.Where(x => x.FechaRecibo >= dateIniNew).ToList();
                }
                if (filtroBusq.ReciboProvisionalFilter.FechaFin != null)
                {
                    System.DateTime dateFin = (System.DateTime)filtroBusq.ReciboProvisionalFilter.FechaFin;
                    System.DateTime dateFinNew = new System.DateTime(dateFin.Year, dateFin.Month, dateFin.Day, 23, 59, 59);
                    lista = lista.Where(x => x.FechaRecibo <= dateFinNew).ToList();
                }
                if (filtroBusq.ReciboProvisionalFilter.CodEmpleado > 0) {
                    lista = lista.Where(x => x.CodEmpleado == filtroBusq.ReciboProvisionalFilter.CodEmpleado).ToList();

                }
            }
            

            int total = lista.Count();

            return new RespuestaBusquedaRecibosProvVob{
                listRecibosProvisional = lista.ToList(),
                    totalelementos = total 
              };

        }

        public int ModificarReciboProvisional(ReciboProvisionalVob registro)
        {
            var reciboRepo = new TFReciboProvisionalRepositorio();

            int numexpediente = reciboRepo.Modificar(registro);

            return numexpediente;

        }
    }

   


}
