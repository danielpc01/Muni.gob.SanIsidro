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
    
    public partial class GrupoTabla
    {
        public GrupoTabla()
        {
            this.Multitabla = new HashSet<Multitabla>();
        }
    
        public string IdGrupo { get; set; }
        public string NombreGrupo { get; set; }
        public Nullable<int> Estado { get; set; }
    
        public virtual ICollection<Multitabla> Multitabla { get; set; }
    }
}
