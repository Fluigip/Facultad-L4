using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabajo_Final_L4.Models;

namespace Trabajo_Final_L4.Pages
{
  public partial class Solicitudes : System.Web.UI.Page
  {
    public List<Solicitud> ListaSolicitudes { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        FinalEntities database = new FinalEntities();
        ListaSolicitudes = database.Solicitud.OrderBy(x => x.fecha).ToList();
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}