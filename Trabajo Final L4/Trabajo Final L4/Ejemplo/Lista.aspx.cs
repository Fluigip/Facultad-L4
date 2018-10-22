using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trabajo_Final_L4.Ejemplo
{
  public partial class Lista : System.Web.UI.Page
  {
    public List<Ejemplo> Ejemplos;

    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        Ejemplos = new List<Ejemplo>
        {
          new Ejemplo { Id = 1, Nombre = "Ejemplo 1", Descripcion = "Descripcion del ejemplo 1" },
          new Ejemplo { Id = 2, Nombre = "Ejemplo 2", Descripcion = "Descripcion del ejemplo 2" },
          new Ejemplo { Id = 3, Nombre = "Ejemplo 3", Descripcion = "Descripcion del ejemplo 3" },
          new Ejemplo { Id = 4, Nombre = "Ejemplo 4", Descripcion = "Descripcion del ejemplo 4" },
          new Ejemplo { Id = 5, Nombre = "Ejemplo 5", Descripcion = "Descripcion del ejemplo 5" },
          new Ejemplo { Id = 6, Nombre = "Ejemplo 6", Descripcion = "Descripcion del ejemplo 6" },
          new Ejemplo { Id = 7, Nombre = "Ejemplo 7", Descripcion = "Descripcion del ejemplo 7" },
          new Ejemplo { Id = 8, Nombre = "Ejemplo 8", Descripcion = "Descripcion del ejemplo 8" },
          new Ejemplo { Id = 9, Nombre = "Ejemplo 9", Descripcion = "Descripcion del ejemplo 9" },
          new Ejemplo { Id = 10, Nombre = "Ejemplo 10", Descripcion = "Descripcion del ejemplo 10" },
          new Ejemplo { Id = 11, Nombre = "Ejemplo 11", Descripcion = "Descripcion del ejemplo 11" },
          new Ejemplo { Id = 12, Nombre = "Ejemplo 12", Descripcion = "Descripcion del ejemplo 12" },
          new Ejemplo { Id = 13, Nombre = "Ejemplo 13", Descripcion = "Descripcion del ejemplo 13" },
          new Ejemplo { Id = 14, Nombre = "Ejemplo 14", Descripcion = "Descripcion del ejemplo 14" },
          new Ejemplo { Id = 15, Nombre = "Ejemplo 15", Descripcion = "Descripcion del ejemplo 15" },
          new Ejemplo { Id = 16, Nombre = "Ejemplo 16", Descripcion = "Descripcion del ejemplo 16" },
          new Ejemplo { Id = 17, Nombre = "Ejemplo 17", Descripcion = "Descripcion del ejemplo 17" },
          new Ejemplo { Id = 18, Nombre = "Ejemplo 18", Descripcion = "Descripcion del ejemplo 18" },
          new Ejemplo { Id = 19, Nombre = "Ejemplo 19", Descripcion = "Descripcion del ejemplo 19" },
          new Ejemplo { Id = 20, Nombre = "Ejemplo 20", Descripcion = "Descripcion del ejemplo 20" } 
        };
      }
      catch (Exception)
      {
        throw;
      }
    }

    [WebMethod]
    public static string Eliminar(int id)
    {
      return "Llegaste papu";
    }

  }
}