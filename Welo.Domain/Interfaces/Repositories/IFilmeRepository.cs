using Welo.Domain.Entities;
using Welo.Domain.Interfaces.Repositories.Base;

namespace Welo.Domain.Interfaces.Repositories
{
    public interface IFilmeRepository : IRepository<FilmeEntity, int>, IRepositoryAsync<FilmeEntity, int>
    {
    }
}
