using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
  public partial class VentaAgroquimicaABM : System.Web.UI.Page
  {
        public List<Agroquimico> ListaAgro { get; set; }
        public Agroquimico agro { get; set; }

        FinalEntities dataBase = new FinalEntities();

        public string marcaComercial { get { return agro == null ? "" : agro.marcaComercial; } }


        protected void Page_Load(object sender, EventArgs e)
        {
            ListaAgro = dataBase.Agroquimico.OrderBy(x => x.marcaComercial).ToList();

        }

        [WebMethod]
        public static string BuscarAgroquimico(int id)
        {
            var jsonObject = new JObject();
            try
            {
                FinalEntities dataBase = new FinalEntities();

                Agroquimico busqueda = dataBase.Agroquimico.Where(x => x.idAgroquimico == id).FirstOrDefault();

                jsonObject["resultado"] = 1;
                jsonObject["marcaComercial"] = busqueda.marcaComercial;
                jsonObject["tipoEnvase"] = busqueda.tipoEnvase;
                jsonObject["unidadMedida"] = busqueda.unidadMedida;
                jsonObject["codigo"] = busqueda.codigo;
                jsonObject["capacidadEnvase"] = busqueda.capacidadEnvase;


            }
            catch (Exception ex)
            {
                jsonObject["resultado"] = 0;
                throw ex;
            }

            return JsonConvert.SerializeObject(jsonObject);
        }
    }
}