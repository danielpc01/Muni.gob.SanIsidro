using Sismuni.Dominio.Entidad.TesoreriaFinanza.GestionPago;
using Sismuni.Infraestructura.Data.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.TesoreriaFinanza.GestionPago
{
    public class TFPagoServicioRepositorio : ITFPagoServicioRepositorio
    {

        public List<SolicitudPagoServicioVob> BuscarSolicitudesPago()
        {

            using (var context = new UPC_MUNIEntities())
            {

                var consulta = from soli in context.SolicitudPagoServicio
                               select new SolicitudPagoServicioVob
                               {
                                   NumSolicitudPago = soli.NumSolicitudPago,
                                   FechaSolicitud = soli.FechaSolicitud,
                                   Monto=soli.Monto,
                                   Motivo=soli.Motivo,
                                   CodContribuyente=soli.CodContribuyente,
                                   CodConceptoPago=soli.CodConceptoPago,
                                   CodEstadoSolicitud=soli.CodEstadoSolicitud,

                                   NombContribuyente=soli.Contribuyente.Nombre,
                                   DescConceptoPago=soli.ConceptoPago.Descripcion,
                                   DescEstadoSolicitud=soli.Multitabla.NombreValor,
                                   DNI = soli.Contribuyente.NumDocumento,
                                   CodMoneda = soli.Multitabla.IdMultitabla

                               };

                return consulta.ToList();
            }


        }

        public List<FormaPagoVob> listaFormaPago()
        {

            using (var context = new UPC_MUNIEntities())
            {

                var consulta = from soli in context.FormaPago
                               select new FormaPagoVob
                               {
                                   Codigo = soli.Codigo,
                                   Descripcion = soli.Descripcion
                               };

                return consulta.ToList();
            }


        }

        public int Agregar(PagoServicioVob pagoServicio)
        {
            PagoServicio pago = new PagoServicio();

            using (var context = new UPC_MUNIEntities())
            {
                pago.FechaPago = pagoServicio.FechaPago;
                pago.NumSolicitudPago = pagoServicio.SolicitudPagoServicio.NumSolicitudPago;
                pago.CodFormaPago = pagoServicio.CodFormaPago;
                pago.CodTipoCambio = pagoServicio.CodTipoCambio;
                pago.CodMonedaPago = pagoServicio.CodMonedaPago;
                pago.MontoPago = pagoServicio.MontoPago;
                pago.CodEstadoPago = pagoServicio.CodEstadoPago;

                context.PagoServicio.Add(pago);
                context.SaveChanges();



                // ACTUALIZAR SOLICITUD
                var solicitud = (from c in context.SolicitudPagoServicio
                                where c.NumSolicitudPago == pagoServicio.SolicitudPagoServicio.NumSolicitudPago
                                select c).First();


                solicitud.CodEstadoSolicitud = pagoServicio.SolicitudPagoServicio.CodEstadoSolicitud;

                //  context.Expediente.Add(exp);

                context.SolicitudPagoServicio.Attach(solicitud);
                context.Entry(solicitud).State = EntityState.Modified;
                context.SaveChanges();


                return Convert.ToInt32(pago.NumeroPago);

            };

        }
       public int ModificarEstadoSolicitud(SolicitudPagoServicioVob registro) {

                using (var context = new UPC_MUNIEntities())
            {
            // ACTUALIZAR SOLICITUD
            var solicitud = (from c in context.SolicitudPagoServicio
                             where c.NumSolicitudPago == registro.NumSolicitudPago
                             select c).First();


            solicitud.CodEstadoSolicitud = registro.CodEstadoSolicitud;

            //  context.Expediente.Add(exp);

            context.SolicitudPagoServicio.Attach(solicitud);
            context.Entry(solicitud).State = EntityState.Modified;
            context.SaveChanges();


            return Convert.ToInt32(registro.NumSolicitudPago);

            };
        }


    }
}
