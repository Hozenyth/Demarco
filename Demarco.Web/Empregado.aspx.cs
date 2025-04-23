using Demarco.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Demarco.Web
{
    public partial class Empregado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Carregar();
        }

        private void Carregar()
        {

            string APIurl = ConfigurationManager.AppSettings["apiUrl"];
            List<EmpregadoDTO> lst = new List<EmpregadoDTO>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(APIurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("Empregado").Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    lst = JsonConvert.DeserializeObject<List<EmpregadoDTO>>(result);
                }
            }
            grv.DataSource = lst;
            grv.DataBind();
        }
    }
}