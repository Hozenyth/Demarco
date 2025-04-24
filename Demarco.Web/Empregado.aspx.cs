using Demarco.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string APIurl = ConfigurationManager.AppSettings["apiUrl"];

            if (!DateTime.TryParse(txtDataNascimento.Text, out DateTime dataNascimento))
            {
                ltMensagemError.Text = "<div class='alert alert-danger'>Data de nascimento inválida.</div>";
                return;
            }
            var empregado = new EmpregadoDTO
            {
                Nome = txtNome.Text,
                CPF = txtCPF.Text,
                DataNascimento = DateTime.Parse(txtDataNascimento.Text)
            };

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(APIurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
              
                string json = JsonConvert.SerializeObject(empregado);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
              
                HttpResponseMessage response = client.PostAsync("Empregado", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string mensagem = response.Content.ReadAsStringAsync().Result;
                    ltMensagemSucesso.Text = $"<div class='alert alert-success' role='alert'>{mensagem}</div>";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "FecharModal", "$('#modalEditarEmpregado').modal('hide');", true);
                }
                else
                {                   
                    string result = response.Content.ReadAsStringAsync().Result;
                    result = result.Replace(". ", ".<br/>");
                    ltMensagemError.Text = $"<div class='alert alert-danger'>{result}</div>";                    
                }

                Carregar(); 
            }
        }


        protected void grv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                CarregarEmpregadoPorId(id);
            }
        }

        private void CarregarEmpregadoPorId(int id)
        {
            string APIurl = ConfigurationManager.AppSettings["apiUrl"];
            EmpregadoDTO empregado = null;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(APIurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("Empregado/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    empregado = JsonConvert.DeserializeObject<EmpregadoDTO>(result);
                }
            }

            if (empregado != null)
            {
                hfEmpregadoId.Value = empregado.ID.ToString();
                TextBox1.Text = empregado.Nome;
                TextBox2.Text = empregado.CPF;
                TextBox3.Text = empregado.DataNascimento.ToString("yyyy-MM-dd");

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modalEditarEmpregado').modal('show');", true);
            }
        }

        protected void btnSalvarEdicao_Click(object sender, EventArgs e)
        {
            string APIurl = ConfigurationManager.AppSettings["apiUrl"];
           
            if (!DateTime.TryParse(TextBox3.Text, out DateTime dataNascimento))
            {
                ltMensagemError.Text = "<div class='alert alert-danger'>Data de nascimento inválida.</div>";
                return;
            }
            var editarEmpregado = new EmpregadoDTO
            {
                ID = int.Parse(hfEmpregadoId.Value),
                Nome = TextBox1.Text,
                CPF = TextBox2.Text,
                DataNascimento = DateTime.Parse(TextBox3.Text)
            };
          
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(APIurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string json = JsonConvert.SerializeObject(editarEmpregado);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync("Empregado", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string mensagem = response.Content.ReadAsStringAsync().Result;
                    ltMensagemSucesso.Text = $"<div class='alert alert-success' role='alert'>{mensagem}</div>";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "FecharModal", "$('#modalEditarEmpregado').modal('hide');", true);
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    result = result.Replace(". ", ".<br/>");
                    ltMensagemError.Text = $"<div class='alert alert-danger'>{result}</div>";
                }

                Carregar();
            }
        }


    }
}