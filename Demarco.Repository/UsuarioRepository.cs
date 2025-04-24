using Demarco.Domain;
using Demarco.Repository.Interface;

namespace Demarco.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DemarcoContext context) : base(context)
        {
        }
    }
}
