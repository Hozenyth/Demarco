using Demarco.DTOs;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Web.Services.Description;
using System.Web.UI;

namespace Demarco.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string apiUrl = ConfigurationManager.AppSettings["apiUrl"];

            var usuario = new
            {
                Email = txtUsuario.Text,
                Password = txtSenha.Text
            };

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string json = JsonConvert.SerializeObject(usuario);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync("Usuario/login", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var resultString = response.Content.ReadAsStringAsync().Result;
                    
                    var mensagem = "Login efetuado com sucesso!";

                    Session["token"] = resultString.ToString().Trim('"');

                    Session["mensagemSucessoLogin"] = $"<div class='alert alert-success' role='alert'>{mensagem}</div>";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MensagemERedirecionamento", @"
                     setTimeout(function() {
                     var msg = document.querySelector('.alert-success');
                     if (msg) msg.style.display = 'none';
                     window.location.href = 'Empregado.aspx';
                     });", true);

                }
                else
                {
                    ltMensagemError.Text = $"<div class='alert alert-danger'>{response}</div>";
                }
            }
        }

        protected void btnIrParaCadastro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cadastro.aspx");
        }


    }
}