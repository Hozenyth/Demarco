using Demarco.DTOs;
using System.Threading.Tasks;

namespace Demarco.Application.Interfaces
{
    public interface IUsuarioApp
    {
        Task<bool> Salvar(UsuarioDTO usuario);
       
    }
}
