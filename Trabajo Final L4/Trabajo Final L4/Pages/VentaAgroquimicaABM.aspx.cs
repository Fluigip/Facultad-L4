using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabajo_Final_L4.Models;

namespace Trabajo_Final_L4.Pages
{
  public partial class VentaAgroquimicaABM : System.Web.UI.Page
  {
        public List<Agroquimico> ListaAgro { get; set; }
        public Agroquimico agro { get; set; }

        FinalEntities dataBase = new FinalEntities();

        public string marcaComercial { get { return agro == null ? "" : agro.marcaComercial; } }


        protected void Page_Load(object sender, EventArgs e)
        {
            ListaAgro = dataBase.Agroquimico.OrderBy(x => x.marcaComercial).ToList();

        }
    }
}