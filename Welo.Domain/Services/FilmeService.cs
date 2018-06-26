using System;
using Welo.Domain.Entities;
using Welo.Domain.Interfaces.Repositories;
using Welo.Domain.Interfaces.Services;

namespace Welo.Domain.Services
{
    [Serializable]
    public class FilmeService : ServiceBaseTEntity<FilmeEntity, int>, IFilmeService
    {
        private readonly IFilmeRepository _repository;

        public FilmeService(IFilmeRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
