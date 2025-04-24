using Demarco.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demarco.Application.Interfaces
{
    public interface IEmpregadoApp
    {
        Task<bool> Salvar(EmpregadoDTO empregado);
        IEnumerable<EmpregadoDTO> RecuperarTodos();
        Task<EmpregadoDTO> GetById(int id);
        Task<bool> Atualizar(EmpregadoDTO empregado);
        Task<bool> ExisteCpfAsync(string cpf);

    }
}
