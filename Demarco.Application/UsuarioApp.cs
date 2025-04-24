using Demarco.Application.Interfaces;
using Demarco.Domain;
using Demarco.DTOs;
using Demarco.Repository.Interface;
using System.Threading.Tasks;

namespace Demarco.Application
{
    public class UsuarioApp : IUsuarioApp
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioApp(IUsuarioRepository repository)
        {
            this._usuarioRepository = repository;
        }

       
        public async Task<bool> Salvar(UsuarioDTO usuario)
        {

            Usuario user = new Usuario(usuario.Nome, usuario.Email, usuario.Email);
            _usuarioRepository.Add(user);
            return await _usuarioRepository.SaveChangesAsync();
        }
    }
}
