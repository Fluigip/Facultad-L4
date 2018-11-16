using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabajo_Final_L4.Models;

namespace Trabajo_Final_L4.Pages
{
  public partial class AgroquimicosABM : System.Web.UI.Page
  {
    public Agroquimico agro;

    public int idAgro;

    FinalEntities dataBase = new FinalEntities();
    public string marcaComercial { get { return agro == null ? "" : agro.MarcaComercial; } }
    public string codigo { get { return agro == null ? "" : agro.Codigo; } }
    public string  principioActivo { get { return agro == null ? "" : agro.PrincipioActivo; } }
    public string tipoEnvase { get { return agro == null ? "" : agro.TipoEnvase; } }
    public string capacidadEnvase { get { return agro == null ? "" : agro.CapacidadEnvase.ToString(); } }
    public string unidadMedida { get { return agro == null ? "" : agro.UnidadMedida; } }

    protected void Page_Load(object sender, EventArgs e)
    {
      string id = Request.QueryString["id"];
      if (!string.IsNullOrWhiteSpace(id))
      {
        idAgro = Convert.ToInt32(id);
        agro = dataBase.Agroquimico.Where(x => x.Id == idAgro).FirstOrDefault();
      }

      string accion = Request.Params["accion"];
      if (accion == "guardar")
      {
        Guardar();

      }
    }
    private void Guardar()
    {
      string marcaComer = Request.Params["mComercial"];
      string codigo = Request.Params["codigo"];
      string principioA = Request.Params["principioA"];
      string tipoEnvase = Request.Params["tEnvase"];
      string capacidadE = Request.Params["capacidadE"];
      string uMedida = Request.Params["uMedida"];

      if (idAgro == 0)
      {
        
        // Insertar nuevo ejemplo
        Agroquimico agro = new Agroquimico();
        agro.MarcaComercial = marcaComer;
        agro.Codigo = codigo;
        agro.PrincipioActivo = principioA;
        agro.TipoEnvase = tipoEnvase;
        agro.CapacidadEnvase = float.Parse(capacidadE);
        agro.UnidadMedida = uMedida;

        dataBase.Agroquimico.Add(agro);

      }
      else
      {
        // Editar ejemplo

        agro.MarcaComercial = marcaComer;
        agro.Codigo = codigo;
        agro.PrincipioActivo = principioA;
        agro.TipoEnvase = tipoEnvase;
        agro.CapacidadEnvase = float.Parse(capacidadE);
        agro.UnidadMedida = uMedida;

      }


      dataBase.SaveChanges();

      Response.Redirect("Agroquimicos.aspx");
    }
  }
}