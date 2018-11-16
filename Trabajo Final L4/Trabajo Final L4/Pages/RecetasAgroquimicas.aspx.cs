using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabajo_Final_L4.Models;

namespace Trabajo_Final_L4.Pages
{
  public partial class RecetasAgroquimicas : System.Web.UI.Page
  {

    public List<RecetaAgroquimica> ListaRecetasAgro { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {

      FinalEntities database = new FinalEntities();

      ListaRecetasAgro = database.RecetaAgroquimica.OrderBy(x => x.Estado).ToList();

    }
  }
}