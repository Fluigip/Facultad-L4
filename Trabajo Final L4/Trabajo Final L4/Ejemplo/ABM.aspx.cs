using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trabajo_Final_L4.Ejemplo
{
  public partial class ABM : System.Web.UI.Page
  {    
    public int Id;
    public Ejemplo Ejemplo;

    public string Nombre { get { return Ejemplo == null ? "" : Ejemplo.Nombre; } }
    public string Descripcion { get { return Ejemplo == null ? "" : Ejemplo.Descripcion; } }


    protected void Page_Load(object sender, EventArgs e)
    {
      string id = Request.QueryString["id"];
      if (!string.IsNullOrWhiteSpace(id))
      {
        Id = Convert.ToInt32(id);
        Ejemplo = new Ejemplo { Id = Convert.ToInt32(id), Nombre = "Ejemplo " + id, Descripcion = "Descripcion del ejemplo " + id };
      }

      string accion = Request.Params["accion"];
      if(accion == "guardar")
      {
        Guardar();
      }        
    }

    private void Guardar()
    {
      string nombre = Request.Params["nombre"];
      string descripcion = Request.Params["descripcion"];

      if(Id == 0)
      {
        // Insertar nuevo ejemplo
      }
      else
      {
        // Editar ejemplo
      }

      Response.Redirect("Lista.aspx");
    }
  }  
}