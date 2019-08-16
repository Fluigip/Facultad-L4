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

    public string fecha { get { return soli == null ? "" : soli.Fecha.ToString("yyyy-MM-dd"); } }
    public int productor { get { return soli == null ? -1 : soli.IdProductor; } }
    public int campoFinca { get { return soli == null ? -1 : soli.IdCampoFinca; } }
    public int agenteFitosanitario { get { return soli == null ? -1 : soli.IdAgenteFitosanitario; } }
    public string estado { get { return soli == null ? "" : soli.Estado; } }

    protected void Page_Load(object sender, EventArgs e)
    {
      string id = Request.QueryString["id"];
      if (!string.IsNullOrWhiteSpace(id))
      {
        idSoli = Convert.ToInt32(id);
        soli = dataBase.Solicitud.Where(x => x.Id == idSoli).FirstOrDefault();
      }

      string accion = Request.Params["accion"];
      if (accion == "guardar")
      {
        Guardar();

      }

      ListaProductor = dataBase.Productor.OrderBy(x => x.Nombre).ToList();
      ListaAgenteFito = dataBase.AgenteFitosanitario.OrderBy(x => x.Nombre).ToList();
      ListaCampoFinca = dataBase.CampoFinca.OrderBy(x => x.Calle).ToList();

    }
    private void Guardar()
    {
      string fecha = Request.Params["fecha"];
      int productor = Convert.ToInt32(Request.Params["selectProductor"]);
      int campoFinca = Convert.ToInt32(Request.Params["selectCampoF"]);
      int agenteFitosanitario = Convert.ToInt32(Request.Params["selectAgenteF"]);
      string estado = Request.Params["estado"];
      


      if (idSoli == 0)
      {
        Solicitud soliA = new Solicitud();
        // Insertar nuevo ejemplo
        soliA.Fecha = DateTime.Parse(fecha);
        soliA.IdProductor = productor;
        soliA.IdCampoFinca = campoFinca;
        soliA.IdAgenteFitosanitario = agenteFitosanitario;
        soliA.Estado = estado;

        dataBase.Solicitud.Add(soliA);

      }
      else
      {
        // Editar ejemplo

        Solicitud soliB = dataBase.Solicitud.Where(x => x.Id == idSoli).FirstOrDefault();

        soliB.Fecha = DateTime.Parse(fecha);
        soliB.IdProductor = productor;
        soliB.IdCampoFinca = campoFinca;
        soliB.IdAgenteFitosanitario = agenteFitosanitario;
        soliB.Estado = estado;
      }


      dataBase.SaveChanges();

      Response.Redirect("Solicitudes.aspx");
    }
  }
}