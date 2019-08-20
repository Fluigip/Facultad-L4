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

    public string fecha { get { return soli == null ? "" : soli.fecha.ToString("yyyy-MM-dd"); } }
    public int productor { get { return soli == null ? -1 : soli.idProductor; } }
    public int campoFinca { get { return soli == null ? -1 : soli.idCampoFinca; } }
    public int agenteFitosanitario { get { return soli == null ? -1 : soli.idAgenteFitosanitario; } }
    public string estado { get { return soli == null ? "" : soli.estado; } }

    protected void Page_Load(object sender, EventArgs e)
    {
      string id = Request.QueryString["id"];
      if (!string.IsNullOrWhiteSpace(id))
      {
        idSoli = Convert.ToInt32(id);
        soli = dataBase.Solicitud.Where(x => x.idSolicitud == idSoli).FirstOrDefault();
      }

      string accion = Request.Params["accion"];
      if (accion == "guardar")
      {
        Guardar();

      }

      ListaProductor = dataBase.Productor.OrderBy(x => x.nombre).ToList();
      ListaAgenteFito = dataBase.AgenteFitosanitario.OrderBy(x => x.nombre).ToList();
      ListaCampoFinca = dataBase.CampoFinca.OrderBy(x => x.calle).ToList();

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
        soliA.fecha = DateTime.Parse(fecha);
        soliA.idProductor = productor;
        soliA.idCampoFinca = campoFinca;
        soliA.idAgenteFitosanitario = agenteFitosanitario;
        soliA.estado = estado;

        dataBase.Solicitud.Add(soliA);

      }
      else
      {
        // Editar ejemplo

        Solicitud soliB = dataBase.Solicitud.Where(x => x.idSolicitud == idSoli).FirstOrDefault();

        soliB.fecha = DateTime.Parse(fecha);
        soliB.idProductor = productor;
        soliB.idCampoFinca = campoFinca;
        soliB.idAgenteFitosanitario = agenteFitosanitario;
        soliB.estado = estado;
      }


      dataBase.SaveChanges();

      Response.Redirect("Solicitudes.aspx");
    }
  }
}