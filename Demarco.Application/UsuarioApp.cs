using Demarco.Application.Interfaces;
using Demarco.Domain;
using Demarco.Domain.Services;
using Demarco.DTOs;
using Demarco.Repository.Interface;
using System.Threading.Tasks;

namespace Demarco.Application
{
    public class UsuarioApp : IUsuarioApp
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;

        public UsuarioApp(IUsuarioRepository repository, IAuthService authService)
        {
            this._usuarioRepository = repository;
            this._authService = authService;
        }

        public async Task<UsuarioDTO> Login(LoginDTO usuario)
        {
            var passwordHash = _authService.ComputeSha256Hash(usuario.Password);

            var user = await _usuarioRepository.GetUserByEmailAndPasswordAsync(usuario.Email, passwordHash);

            if (user == null)
            {
                return null;
            }

            var token = _authService.GenerateJwtToken(user.Email);

            return new UsuarioDTO
            {
                Token = token,
                Email = user.Email
            };
        }

        public async Task<bool> Salvar(UsuarioDTO usuario)
        {
            var passwordHash = _authService.ComputeSha256Hash(usuario.Password);

            Usuario user = new Usuario(usuario.Nome, usuario.Email, passwordHash);

            _usuarioRepository.Add(user);

            return await _usuarioRepository.SaveChangesAsync();
        }
    }
}
