//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FerreteriaProMAX.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public Nullable<float> Total { get; set; }
        public Nullable<decimal> Iva { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<decimal> Descuento { get; set; }
        public Nullable<int> IdPago { get; set; }
        public Nullable<int> idVenta { get; set; }
    
        public virtual Ventas Ventas { get; set; }
        public virtual TipoPago TipoPago { get; set; }
    }
}
