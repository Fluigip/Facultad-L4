//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Trabajo_Final_L4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Productor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productor()
        {
            this.CampoFinca = new HashSet<CampoFinca>();
            this.RecetaAgroquimica = new HashSet<RecetaAgroquimica>();
            this.Solicitud = new HashSet<Solicitud>();
        }
    
        public int idProductor { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public string cuit { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampoFinca> CampoFinca { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecetaAgroquimica> RecetaAgroquimica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
