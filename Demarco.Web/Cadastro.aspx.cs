using Demarco.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Demarco.Web
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string APIurl = ConfigurationManager.AppSettings["apiUrl"];
            var usuario = new UsuarioDTO
            {
                Nome = txtNome.Text,
                Email = txtUsuario.Text,
                Password = txtSenha.Text,
            };

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(APIurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string json = JsonConvert.SerializeObject(usuario);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync("Usuario", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string mensagem = response.Content.ReadAsStringAsync().Result;
                    ltMensagemSucesso.Text = $"<div class='alert alert-success' role='alert'>{mensagem}</div>";

                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    result = result.Replace(". ", ".<br/>");
                    ltMensagemError.Text = $"<div class='alert alert-danger'>{result}</div>";
                }
            }
        }

        protected void btnVoltarLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

    }
}