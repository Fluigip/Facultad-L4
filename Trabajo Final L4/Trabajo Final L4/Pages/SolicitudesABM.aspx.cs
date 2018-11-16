using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabajo_Final_L4.Models;

namespace Trabajo_Final_L4.Pages
{
  public partial class SolicitudesABM : System.Web.UI.Page
  {

    public Solicitud soli;

    public int idSoli;

    public List<Productor> ListaProductor { get; set; }
    public List<CampoFinca> ListaCampoFinca { get; set; }
    public List<AgenteFitosanitario> ListaAgenteFito { get; set; }

    FinalEntities dataBase = new FinalEntities();

    public string fecha { get { return soli == null ? "" : soli.fecha.ToString(); } }
    public string productor { get { return soli == null ? "" : soli.Productor.Nombre; } }
    public string campoFinca { get { return soli == null ? "" : soli.CampoFinca.Calle; } }
    public string agenteFitosanitario { get { return soli == null ? "" : soli.AgenteFitosanitario.Nombre; } }
    public string estado { get { return soli == null ? "" : soli.estado; } }

    protected void Page_Load(object sender, EventArgs e)
    {
      string id = Request.QueryString["id"];
      if (!string.IsNullOrWhiteSpace(id))
      {
        idSoli = Convert.ToInt32(id);
        soli = dataBase.Solicitud.Where(x => x.id == idSoli).FirstOrDefault();
      }

      string accion = Request.Params["accion"];
      if (accion == "guardar")
      {
        Guardar();

      }
    }
    private void Guardar()
    {
      string fecha = Request.Params["fecha"];
      string productor = Request.Params["productor"];
      string campoFinca = Request.Params["campoFinca"];
      string agenteFitosanitario = Request.Params["agenteFito"];
      string estado = Request.Params["estado"];
      Solicitud soliA = new Solicitud();
      

      if (idSoli == 0)
      {

        // Insertar nuevo ejemplo
        
        soliA.fecha = DateTime.Parse(fecha);
        soliA.Productor.Nombre = productor;
        soliA.CampoFinca.Calle = campoFinca;
        soliA.AgenteFitosanitario.Nombre = agenteFitosanitario;
        soliA.estado = estado;
        dataBase.Solicitud.Add(soliA);

      }
      else
      {
        // Editar ejemplo
        soliA.fecha = DateTime.Parse(fecha);
        soliA.Productor.Nombre = productor;
        soliA.CampoFinca.Calle = campoFinca;
        soliA.AgenteFitosanitario.Nombre = agenteFitosanitario;
        soliA.estado = estado;

      }


      dataBase.SaveChanges();

      Response.Redirect("Solicitudes.aspx");
    }
  }
}