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
    
    public partial class Cargo
    {
        public Cargo()
        {
            this.UsuarioTrabajador = new HashSet<UsuarioTrabajador>();
        }
    
        public int IdCargo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public string UsuRegistro { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public string UsuModifica { get; set; }
        public Nullable<System.DateTime> FechaModifica { get; set; }
    
        public virtual ICollection<UsuarioTrabajador> UsuarioTrabajador { get; set; }
    }
}
