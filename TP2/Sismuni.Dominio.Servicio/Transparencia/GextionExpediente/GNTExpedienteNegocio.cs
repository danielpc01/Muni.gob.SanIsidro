﻿using Sismuni.Dominio.Entidad.Transparencia;
using Sismuni.Dominio.Entidad.Transparencia.GestionExpediente;
using Sismuni.Dominio.Servicio.Enumeraciones;
using Sismuni.Dominio.Servicio.Recursos;
using Sismuni.Infraestructura.Data.Repositorios.General;
using Sismuni.Infraestructura.Data.Repositorios.Transparencia.GestionExpediente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Dominio.Servicio.Transparencia
{
    public class GNTExpedienteNegocio : IGNTExpedienteNegocio
    {

        public EditorExpedienteVob ObtenerEditor(int? id)
        {

            var expedienterepositorio = new GNTExpedienteRepositorio();
            var generalrepositorio = new MultitablaRepositorio();


            ExpedienteVob objexpediente = new ExpedienteVob();
            string valor = string.Empty;
            string texto = PrimerValorEnum.Seleccione.ToString();


            if (id == null) { id = 0; };

            var expediente = expedienterepositorio.BuscarExpedienteporId(Convert.ToInt32(id));

            var tipos_expediente = generalrepositorio.ListarTablas(GrupoTabla.TipoExpediente);

            tipos_expediente.Add(new Entidad.General.ElementoVob { Valor = valor, Texto = texto });

            tipos_expediente = tipos_expediente.OrderBy(x=> x.Valor).ToList();

            if (expediente != null)
            {
                objexpediente = expediente;
            }

            return new EditorExpedienteVob
            {
                Expediente = objexpediente,
                Tipo_Expedientes = tipos_expediente
            };


        }

        public int Agregar(RegistrarExpedienteVob registro)
        {
            var expedienterepositorio = new GNTExpedienteRepositorio();

            int numexpediente = expedienterepositorio.Agregar(registro.Expediente);

            return numexpediente;

        }

        public int Modificar(RegistrarExpedienteVob registro)
        {
            var expedienterepositorio = new GNTExpedienteRepositorio();

            int numexpediente = expedienterepositorio.Modificar(registro.Expediente);

            return numexpediente;

        }

        public RespuestaBusquedaExpedientesVob BuscarExpedientes(SolicitudBusquedaExpedientesVob solicitud)
        {
            List<ExpedienteVob> lista = new List<ExpedienteVob>();
            var expedienterepositorio = new GNTExpedienteRepositorio();

            lista = expedienterepositorio.BuscarExpedientes();

            lista = lista.Where(x => x.Estado == 1).ToList();

            if (solicitud.ExpedienteFilter.Codigo_Expediente != null)
            {
                if (solicitud.ExpedienteFilter.Codigo_Expediente > 0)
                {
                    lista = lista.Where(x => x.Codigo_Expediente == solicitud.ExpedienteFilter.Codigo_Expediente).ToList();
                }
            }

            if (solicitud.ExpedienteFilter.NumeroSolicitud != null)
            {
                if (solicitud.ExpedienteFilter.NumeroSolicitud > 0)
                {
                    lista = lista.Where(x => x.NumeroSolicitud == solicitud.ExpedienteFilter.NumeroSolicitud).ToList();
                }
            }

            if (solicitud.ExpedienteFilter.FECHAINICIO != null && solicitud.ExpedienteFilter.FECHAFIN != null)
            {
                lista = lista.Where(x => x.FechaExpediente >= solicitud.ExpedienteFilter.FECHAINICIO && x.FechaExpediente <= solicitud.ExpedienteFilter.FECHAFIN).ToList();
            }

            int total = lista.Count();

            return new RespuestaBusquedaExpedientesVob{
                    listaexpedientes = lista.OrderByDescending(x => x.FechaExpediente).ToList(),
                    totalelementos = total 
              };

        }
    }
}
