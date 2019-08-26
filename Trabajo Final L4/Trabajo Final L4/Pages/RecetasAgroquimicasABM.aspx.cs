using Newtonsoft.Json;
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

    public RecetaAgroquimica recetaAgro;    
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

    public string fecha { get { return recetaAgro == null ? "" : recetaAgro.fechaReceta.ToString("yyyy-MM-dd"); } }
    public int agenteFito { get { return recetaAgro == null ? -1 : recetaAgro.idAgenteFitosanitario; } }
    public int productor { get { return recetaAgro == null ? -1 : recetaAgro.idProductor; } }
    public int campoFinca { get { return recetaAgro == null ? -1 : recetaAgro.idCampoFinca; } }
    public string diagnostico { get { return recetaAgro == null ? "" : recetaAgro.diagnostico; } }
    public string estado { get { return recetaAgro == null ? "" : recetaAgro.estado; } }    
    public int cantidad { get { return recetaD == null ? -1 : recetaD.cantidad; } }
    public string marcaC { get { return recetaD == null ? "" : recetaD.Agroquimico.marcaComercial; } }
    public string productosRD { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
      string id = Request.QueryString["id"];
      List<DetalleTmp> detalles = new List<DetalleTmp>();
      
      if (!string.IsNullOrWhiteSpace(id))
      {
        idRecetaA = Convert.ToInt32(id);
        recetaAgro = dataBase.RecetaAgroquimica.Where(x => x.idRecetaAgroquimica == idRecetaA).FirstOrDefault();

        foreach (var el in recetaAgro.RecetaAgroquimicaDetalle)
        {
          DetalleTmp det = new DetalleTmp();
          det.idProducto = el.idAgroquimico.ToString();
          det.cantidad = el.cantidad.ToString();
          det.marcaComercial = el.Agroquimico.marcaComercial;
          detalles.Add(det);
        }
      }
        productosRD = JsonConvert.SerializeObject(detalles);

      string accion = Request.Params["accion"];
      if (accion == "guardar")
      {
        Guardar();

      }

      ListaProductor = dataBase.Productor.OrderBy(x => x.nombre).ToList();
      ListaAgenteFito = dataBase.AgenteFitosanitario.OrderBy(x => x.nombre).ToList();
      ListaCampoFinca = dataBase.CampoFinca.OrderBy(x => x.calle).ToList();
      ListaVendedor = dataBase.Vendedor.OrderBy(x => x.cuit).ToList();
      ListaAgro = dataBase.Agroquimico.OrderBy(x => x.marcaComercial).ToList();
      ListaDetalleReceta = dataBase.RecetaAgroquimicaDetalle.OrderBy(x => x.cantidad).ToList();

    }
    private void Guardar()
    {
      try
      {
        string fecha = Request.Params["fecha"];
        int agenteFitosanitario = Convert.ToInt32(Request.Params["selectAF"]);
        int productor = Convert.ToInt32(Request.Params["selectProduc"]);
        int campoFinca = Convert.ToInt32(Request.Params["selectCF"]);
        string diagnostico = Request.Params["diagnostico"];
        string estado = Request.Params["estado"];
        string productos = Request.Params["listaProductos"];
        List<DetalleTmp> detalles = JsonConvert.DeserializeObject<List<DetalleTmp>>(productos);

        RecetaAgroquimica recetaA = new RecetaAgroquimica();

        if (idRecetaA == 0)
        {
          // Insertar nuevo ejemplo
          recetaA.fechaReceta = DateTime.Parse(fecha);
          recetaA.idProductor = productor;
          recetaA.idCampoFinca = campoFinca;
          recetaA.idAgenteFitosanitario = agenteFitosanitario;
          recetaA.estado = estado;
          recetaA.diagnostico = diagnostico;
          recetaA.idVendedor = 6;

          //Si agrego producto, insertarlo en receta
          dataBase.RecetaAgroquimica.Add(recetaA);
          dataBase.SaveChanges();
        }
        else
        {
          recetaA = dataBase.RecetaAgroquimica.FirstOrDefault(x => x.idRecetaAgroquimica == idRecetaA);

          // Editar ejemplo
          recetaA.fechaReceta = DateTime.Parse(fecha);
          recetaA.idProductor = productor;
          recetaA.idCampoFinca = campoFinca;
          recetaA.idAgenteFitosanitario = agenteFitosanitario;
          recetaA.estado = estado;
          recetaA.diagnostico = diagnostico;

          //Vaciar tabla de detalles
          List<RecetaAgroquimicaDetalle> detallesR = dataBase.RecetaAgroquimicaDetalle.Where(x => x.idRecetaAgroquimica == idRecetaA).ToList();
          dataBase.RecetaAgroquimicaDetalle.RemoveRange(detallesR);                   
        }

        if (detalles != null)
        {
          foreach (var el in detalles)
          {
            RecetaAgroquimicaDetalle detalleAGuardar = new RecetaAgroquimicaDetalle();
            detalleAGuardar.idAgroquimico = Convert.ToInt32(el.idProducto);
            detalleAGuardar.cantidad = Convert.ToInt32(el.cantidad);
            detalleAGuardar.idRecetaAgroquimica = recetaA.idRecetaAgroquimica;

            dataBase.RecetaAgroquimicaDetalle.Add(detalleAGuardar);
          }
        }

        dataBase.SaveChanges();
        Response.Redirect("RecetasAgroquimicas.aspx");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }
  }
  public class DetalleTmp
  {
    public string idProducto;
    public string marcaComercial;
    public string cantidad;

  }

}