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
    public string marcaComercial { get { return agro == null ? "" : agro.marcaComercial; } }
    public string codigo { get { return agro == null ? "" : agro.codigo; } }
    public string  principioActivo { get { return agro == null ? "" : agro.principioActivo; } }
    public string tipoEnvase { get { return agro == null ? "" : agro.tipoEnvase; } }
    public string capacidadEnvase { get { return agro == null ? "" : agro.capacidadEnvase.ToString(); } }
    public string unidadMedida { get { return agro == null ? "" : agro.unidadMedida; } }

    protected void Page_Load(object sender, EventArgs e)
    {
      string id = Request.QueryString["id"];
      if (!string.IsNullOrWhiteSpace(id))
      {
        idAgro = Convert.ToInt32(id);
        agro = dataBase.Agroquimico.Where(x => x.idAgroquimico == idAgro).FirstOrDefault();
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
        agro.marcaComercial = marcaComer;
        agro.codigo = codigo;
        agro.principioActivo = principioA;
        agro.tipoEnvase = tipoEnvase;
        agro.capacidadEnvase = float.Parse(capacidadE);
        agro.unidadMedida = uMedida;

        dataBase.Agroquimico.Add(agro);

      }
      else
      {
        // Editar ejemplo

        agro.marcaComercial = marcaComer;
        agro.codigo = codigo;
        agro.principioActivo = principioA;
        agro.tipoEnvase = tipoEnvase;
        agro.capacidadEnvase = float.Parse(capacidadE);
        agro.unidadMedida = uMedida;

      }


      dataBase.SaveChanges();

      Response.Redirect("Agroquimicos.aspx");
    }
  }
}