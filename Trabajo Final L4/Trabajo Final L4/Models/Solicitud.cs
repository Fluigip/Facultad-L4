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
    
    public partial class Solicitud
    {
        public int id { get; set; }
        public System.DateTime fecha { get; set; }
        public int idProductor { get; set; }
        public int idCampoFinca { get; set; }
        public int idAgenteFitosanitario { get; set; }
        public string estado { get; set; }
    
        public virtual AgenteFitosanitario AgenteFitosanitario { get; set; }
        public virtual CampoFinca CampoFinca { get; set; }
        public virtual Productor Productor { get; set; }
    }
}
