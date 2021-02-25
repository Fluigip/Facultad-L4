using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabajo_Final_L4.Models;

namespace Trabajo_Final_L4.Pages
{
  public partial class Agroquimicos : System.Web.UI.Page
  {
    public List<Agroquimico> ListaAgroquimicos { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
      FinalEntities database = new FinalEntities();

      ListaAgroquimicos = database.Agroquimico.OrderBy(x => x.marcaComercial).ToList();

    }

    [WebMethod]
    public static string Eliminar(int id)
    {
      FinalEntities database = new FinalEntities();

      Agroquimico agro = database.Agroquimico.Where(x => x.idAgroquimico == id).FirstOrDefault();

      database.Agroquimico.Remove(agro);

      database.SaveChanges();

      return "";
    }
  }
}