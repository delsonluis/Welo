using Welo.Data.Repository.LiteDB;
using Welo.Domain.Entities;
using Welo.Domain.Interfaces.Repositories;

namespace Welo.Data
{
    public class FilmeRepository : LiteDBRepository<FilmeEntity, int>, IFilmeRepository
    {
        public FilmeRepository()
        {
            base.DbContext = new CommandsContext();
        }
    }
}
