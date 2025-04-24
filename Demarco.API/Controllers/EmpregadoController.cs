using Demarco.Application.Interfaces;
using Demarco.Application.Validators;
using Demarco.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Demarco.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpregadoController : Controller
    {
        private readonly IEmpregadoApp _app;
        public EmpregadoController(IEmpregadoApp app)
        {
            this._app = app;
        }

        [HttpGet]
        [ProducesResponseType(typeof(EmpregadoDTO[]), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_app.RecuperarTodos());
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmpregadoDTO), (int)HttpStatusCode.Created)]       
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post(EmpregadoDTO empregado)
        {
            try
            {               
                var validator = new EmpregadoDTOValidator();
                var validationResult = await validator.ValidateAsync(empregado);
               
                if (!validationResult.IsValid)
                {                  
                    var mensagemErro = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                    return StatusCode(StatusCodes.Status400BadRequest, mensagemErro);
                }

                var cpfExistente = await _app.ExisteCpfAsync(empregado.CPF);
                if (cpfExistente)
                {                   
                    return StatusCode(StatusCodes.Status400BadRequest, "CPF já cadastrado");
                }

                var sucesso = await _app.Salvar(empregado);

                if (sucesso)
                {                    
                    return StatusCode(StatusCodes.Status201Created, "Empregado Criado");
                }

                return BadRequest(new { Message = "Erro ao salvar empregado." });

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmpregadoDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var empregado = await _app.GetById(id); 
                if (empregado == null)
                {                   
                    return this.StatusCode(StatusCodes.Status404NotFound, "Empregado não encontrado");
                }

                return Ok(empregado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut]
        [ProducesResponseType(typeof(EmpregadoDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(EmpregadoDTO empregado)
        {
            try
            {
                var validator = new EmpregadoDTOValidator();
                var validationResult = await validator.ValidateAsync(empregado);

                if (!validationResult.IsValid)
                {
                    var mensagemErro = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                    return StatusCode(StatusCodes.Status400BadRequest, mensagemErro);
                }
                var sucesso = await _app.Atualizar(empregado);

                if (sucesso) 
                {
                    return this.StatusCode(StatusCodes.Status200OK, "Empregado Atualizado");
                }
                return BadRequest("Não foi possível atualizar o empregado.");
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
