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
    
    public partial class MovimientoCajaChica
    {
        public long CodigoMovimiento { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaActualizacion { get; set; }
        public Nullable<decimal> MontoMovimiento { get; set; }
        public string CodTipoMovimiento { get; set; }
        public string CodOrigenMovimiento { get; set; }
    
        public virtual Multitabla Multitabla { get; set; }
        public virtual Multitabla Multitabla1 { get; set; }
    }
}