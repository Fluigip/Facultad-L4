using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabajo_Final_L4.Models;

namespace Trabajo_Final_L4.Pages
{
  public partial class RecetasAgroquimicasABM : System.Web.UI.Page
  {

    public RecetaAgroquimica recetaA;    
    public RecetaAgroquimicaDetalle recetaD;
    public Vendedor vendedor;
    public int idRecetaA;

    public List<Productor> ListaProductor { get; set; }
    public List<Agroquimico> ListaAgro { get; set; }
    public List<CampoFinca> ListaCampoFinca { get; set; }
    public List<AgenteFitosanitario> ListaAgenteFito { get; set; }
    public List<RecetaAgroquimicaDetalle> ListaDetalleReceta { get; set; }
    public List<Vendedor> ListaVendedor { get; set; }

    FinalEntities dataBase = new FinalEntities();

    public string fecha { get { return recetaA == null ? "" : recetaA.fechaReceta.ToString("yyyy-MM-dd"); } }
    public int agenteFito { get { return recetaA == null ? -1 : recetaA.idAgenteFitosanitario; } }
    public int productor { get { return recetaA == null ? -1 : recetaA.idProductor; } }
    public int campoFinca { get { return recetaA == null ? -1 : recetaA.idCampoFinca; } }
    public string diagnostico { get { return recetaA == null ? "" : recetaA.diagnostico; } }
    public string estado { get { return recetaA == null ? "" : recetaA.estado; } }    
    public int cantidad { get { return recetaD == null ? -1 : recetaD.cantidad; } }
    public string marcaC { get { return recetaD == null ? "" : recetaD.Agroquimico.marcaComercial; } }

    protected void Page_Load(object sender, EventArgs e)
    {
      string id = Request.QueryString["id"];
      if (!string.IsNullOrWhiteSpace(id))
      {
        idRecetaA = Convert.ToInt32(id);
        recetaA = dataBase.RecetaAgroquimica.Where(x => x.idRecetaAgroquimica == idRecetaA).FirstOrDefault();
      }

      string accion = Request.Params["accion"];
      if (accion == "guardar")
      {
        Guardar();

      }

      ListaProductor = dataBase.Productor.OrderBy(x => x.nombre).ToList();
      ListaAgenteFito = dataBase.AgenteFitosanitario.OrderBy(x => x.nombre).ToList();
      ListaCampoFinca = dataBase.CampoFinca.OrderBy(x => x.calle).ToList();
      ListaDetalleReceta = dataBase.RecetaAgroquimicaDetalle.OrderBy(x => x.cantidad).ToList();
      ListaVendedor = dataBase.Vendedor.OrderBy(x => x.cuit).ToList();
      ListaAgro = dataBase.Agroquimico.OrderBy(x => x.marcaComercial).ToList();

    }
    private void Guardar()
    {
      string fecha = Request.Params["fecha"];
      int productor = Convert.ToInt32(Request.Params["selectProductor"]);
      int campoFinca = Convert.ToInt32(Request.Params["selectCampoF"]);
      int agenteFitosanitario = Convert.ToInt32(Request.Params["selectAgenteF"]);
      string estado = Request.Params["estado"];
      string diagnostico = Request.Params["diagnostico"];
      string marcaComer = Request.Params["mComercial"];
      string codigo = Request.Params["codigo"];
      string principioA = Request.Params["principioA"];
      int cantidad = Convert.ToInt32(Request.Params["cantidad"]);

      Solicitud soliA = new Solicitud();

      if (idRecetaA == 0)
      {
        // Insertar nuevo ejemplo
        RecetaAgroquimica recetaA = new RecetaAgroquimica();
        recetaA.fechaReceta = DateTime.Parse(fecha);
        recetaA.idProductor = productor;
        recetaA.idCampoFinca = campoFinca;
        recetaA.idAgenteFitosanitario = agenteFitosanitario;
        recetaA.estado = estado;
        recetaA.diagnostico = diagnostico;
        
        //Si agrego producto, insertarlo en receta

        dataBase.RecetaAgroquimica.Add(recetaA);

      }
      else
      {
        // Editar ejemplo
        recetaA.fechaReceta = DateTime.Parse(fecha);
        recetaA.idProductor = productor;
        recetaA.idCampoFinca = campoFinca;
        recetaA.idAgenteFitosanitario = agenteFitosanitario;
        recetaA.estado = estado;
        recetaA.diagnostico = diagnostico;

      }


      dataBase.SaveChanges();

      Response.Redirect("Solicitudes.aspx");
    }
  }
}