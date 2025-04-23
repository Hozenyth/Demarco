using Demarco.Application.Interfaces;
using Demarco.Domain;
using Demarco.DTOs;
using Demarco.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demarco.Application
{
    public class EmpregadoApp : IEmpregadoApp
    {
        private readonly IEmpregadoRepository _empregadoRepository;

        public EmpregadoApp(IEmpregadoRepository repository)
        {
            this._empregadoRepository = repository;
        }

        public async Task<bool> Salvar(EmpregadoDTO empregado)
        {
            Empregado emp = new Empregado(empregado.ID, empregado.CPF, empregado.Nome, empregado.DataNascimento);
            _empregadoRepository.Add(emp);
            return await _empregadoRepository.SaveChangesAsync();
        }

        public IEnumerable<EmpregadoDTO> RecuperarTodos()
        {
            return _empregadoRepository.GetAsync().Result.Select(e => new EmpregadoDTO
            {
                ID = e.ID,
                CPF = e.CPF,
                Nome = e.Nome,
                DataNascimento = e.DataNascimento
            });
        }
    }
}
