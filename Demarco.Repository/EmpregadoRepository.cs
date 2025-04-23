using Demarco.Domain;
using Demarco.Repository.Interface;

namespace Demarco.Repository
{
    public class EmpregadoRepository : BaseRepository<Empregado>, IEmpregadoRepository
    {
        public EmpregadoRepository(DemarcoContext context) : base(context)
        {
        }
    }
}
