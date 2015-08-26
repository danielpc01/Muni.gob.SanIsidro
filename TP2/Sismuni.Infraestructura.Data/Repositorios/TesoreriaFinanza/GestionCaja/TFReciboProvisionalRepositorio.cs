using Sismuni.Dominio.Entidad.TesoreriaFinanza.ReciboProvisional;
using Sismuni.Dominio.Entidad.Transparencia;
using Sismuni.Infraestructura.Data.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.TesoreriaFinanza.GestionCaja
{
    public class TFReciboProvisionalRepositorio : ITFReciboProvisionalRepositorio
    {

        public List<ReciboProvisionalVob> BuscarRecibosProvisionales()
        {

            using (var context = new UPC_MUNIEntities())
            {

                var consulta = from objRecibo in context.ReciboProvisional
                               select new ReciboProvisionalVob
                               {
                                   NumeroRecibo = objRecibo.NumeroRecibo,
                                   Monto = objRecibo.Monto,
                                   Concepto = objRecibo.ConceptoRecibo.Descripcion,
                                   FechaRecibo = objRecibo.FechaCreacion,
                                   Estado = objRecibo.Multitabla.NombreValor,
                                   Motivo = objRecibo.Motivo,
                                   CodEstado=objRecibo.CodEstado,
                                   CodEmpleado=objRecibo.CodTrabajador
                               };

                return consulta.ToList();
            }


        }

        public int Modificar(ReciboProvisionalVob reciboProvisional)
        {
            

            DateTime fecha = new DateTime();
            fecha = DateTime.Today;

            using (var context = new UPC_MUNIEntities())
            {



                var expmodif = (from c in context.ReciboProvisional
                                where c.NumeroRecibo == reciboProvisional.NumeroRecibo
                                select c).First();


                expmodif.CodEstado = reciboProvisional.CodEstado;
                expmodif.Motivo = reciboProvisional.MotivoRechazo;
               
                //  context.Expediente.Add(exp);

                context.ReciboProvisional.Attach(expmodif);
                context.Entry(expmodif).State = EntityState.Modified;
                context.SaveChanges();


                if (reciboProvisional.CodEstado == "0006001")
                { 
                context.MovimientoCajaChica.Add(new MovimientoCajaChica
                {
                   

                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    MontoMovimiento =expmodif.Monto,
                    CodTipoMovimiento = "0007003",
                    CodOrigenMovimiento = "0008001"

                });
                context.SaveChanges();
                }

                return Convert.ToInt32(reciboProvisional.NumeroRecibo);

            };



        }


    }
}
