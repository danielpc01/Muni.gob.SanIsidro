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
    
    public partial class Estado
    {
        public Estado()
        {
            this.BienMueble = new HashSet<BienMueble>();
            this.SolicitudAsignacionBienMueble = new HashSet<SolicitudAsignacionBienMueble>();
            this.UsuarioTrabajador = new HashSet<UsuarioTrabajador>();
        }
    
        public int IdEstado { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string UsuRegistro { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public string UsuModifica { get; set; }
        public Nullable<System.DateTime> FechaModifica { get; set; }
    
        public virtual ICollection<BienMueble> BienMueble { get; set; }
        public virtual ICollection<SolicitudAsignacionBienMueble> SolicitudAsignacionBienMueble { get; set; }
        public virtual ICollection<UsuarioTrabajador> UsuarioTrabajador { get; set; }
    }
}
