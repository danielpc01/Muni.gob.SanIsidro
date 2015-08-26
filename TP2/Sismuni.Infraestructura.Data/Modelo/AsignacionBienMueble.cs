//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sismuni.Infraestructura.Data.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class AsignacionBienMueble
    {
        public int IdAsignacion { get; set; }
        public int IdSolicitudAsignacion { get; set; }
        public int IdUsuarioTrabajador { get; set; }
        public int IdBienMueble { get; set; }
        public int Cantidad { get; set; }
        public System.DateTime FechaAsignacion { get; set; }
        public string UsuRegistro { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public string UsuModifica { get; set; }
        public Nullable<System.DateTime> FechaModifica { get; set; }
    
        public virtual BienMueble BienMueble { get; set; }
        public virtual SolicitudAsignacionBienMueble SolicitudAsignacionBienMueble { get; set; }
        public virtual UsuarioTrabajador UsuarioTrabajador { get; set; }
    }
}
