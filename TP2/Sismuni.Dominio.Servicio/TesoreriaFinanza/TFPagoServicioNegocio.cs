using Sismuni.Dominio.Entidad.TesoreriaFinanza.GestionPago;
//using Sismuni.Dominio.Servicio.TesoreriaFinanza;
using Sismuni.Infraestructura.Data.Repositorios.TesoreriaFinanza.GestionPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Servicio.TesoreriaFinanza
{
    public class TFPagoServicioNegocio : ITFPagoServicioNegocio
    {
        public RespuestaBusquedaSolicitudPagoServVob BuscarSolicitudesPagoSericio(SolicitudBusquedaSolicitudPagoServVob filtroBusq)
        {
            List<SolicitudPagoServicioVob> lista = new List<SolicitudPagoServicioVob>();
            var pagoServRepo = new TFPagoServicioRepositorio();

            lista = pagoServRepo.BuscarSolicitudesPago();

            if (filtroBusq.SolicitudPagoServFilter != null)
            {
                if (filtroBusq.SolicitudPagoServFilter.NumSolicitudPago > 0)
                {
                    lista = lista.Where(x => x.NumSolicitudPago == filtroBusq.SolicitudPagoServFilter.NumSolicitudPago).ToList();
                }
                if (filtroBusq.SolicitudPagoServFilter.FechaInicio != null)
                {
                    System.DateTime dateIni = (System.DateTime)filtroBusq.SolicitudPagoServFilter.FechaInicio;
                    System.DateTime dateIniNew = new System.DateTime(dateIni.Year, dateIni.Month, dateIni.Day, 0, 0, 0);


                    lista = lista.Where(x => x.FechaSolicitud >= dateIniNew).ToList();
                }
                if (filtroBusq.SolicitudPagoServFilter.FechaFin != null)
                {
                    System.DateTime dateFin = (System.DateTime)filtroBusq.SolicitudPagoServFilter.FechaFin;
                    System.DateTime dateFinNew = new System.DateTime(dateFin.Year, dateFin.Month, dateFin.Day, 23, 59, 59);
                    lista = lista.Where(x => x.FechaSolicitud <= dateFinNew).ToList();
                }
                if (filtroBusq.SolicitudPagoServFilter.CodEstadoSolicitud != null && !filtroBusq.SolicitudPagoServFilter.CodEstadoSolicitud.Equals("-1"))
                {
                    lista = lista.Where(x => x.CodEstadoSolicitud == filtroBusq.SolicitudPagoServFilter.CodEstadoSolicitud).ToList();
                }
                if (filtroBusq.SolicitudPagoServFilter.DNI != null && !filtroBusq.SolicitudPagoServFilter.DNI.Equals(""))
                {
                    lista = lista.Where(x => x.DNI == filtroBusq.SolicitudPagoServFilter.DNI).ToList();
                }
          
            }

            int total = lista.Count();

            return new RespuestaBusquedaSolicitudPagoServVob{
                listaSolicitudPagoServicio = lista.ToList(),
                    totalElementos = total 
              };

        }

        public int AgregarPagoServicio(PagoServicioVob registro)
        {
            var pagoServRepo = new TFPagoServicioRepositorio();

            int numPagoServicio = pagoServRepo.Agregar(registro);

            return numPagoServicio;

        }

        public int ModificarEstadoSolicitudPagoServicio(SolicitudPagoServicioVob registro) {
            var pagoServRepo = new TFPagoServicioRepositorio();

            int numPagoServicio = pagoServRepo.ModificarEstadoSolicitud(registro);

            return numPagoServicio; 
        }


        public List<FormaPagoVob> listaFormaPago()
        {
            var pagoServRepo = new TFPagoServicioRepositorio();

            List<FormaPagoVob> numPagoServicio = pagoServRepo.listaFormaPago();

            return numPagoServicio;

        }
    }

   


}
