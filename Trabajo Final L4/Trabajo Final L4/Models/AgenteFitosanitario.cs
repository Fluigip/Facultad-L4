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
    
    public partial class AgenteFitosanitario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AgenteFitosanitario()
        {
            this.RecetaAgroquimica = new HashSet<RecetaAgroquimica>();
        }
    
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int IdRecetaAgroquimica { get; set; }
    
        public virtual AgenteFitosanitario AgenteFitosanitario1 { get; set; }
        public virtual AgenteFitosanitario AgenteFitosanitario2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RecetaAgroquimica> RecetaAgroquimica { get; set; }
    }
}
