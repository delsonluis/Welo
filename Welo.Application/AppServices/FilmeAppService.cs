using System;
using Welo.Application.Interfaces;
using Welo.Domain.Entities;
using Welo.Domain.Interfaces.Services;

namespace Welo.Application.AppServices
{
    [Serializable]
    public class FilmeAppService : AppServiceBase<FilmeEntity, int>, IFilmeAppService
    {
        private readonly IFilmeService _service;

        public FilmeAppService(IFilmeService service) : base(service)
        {
            _service = service;
        }
    }
}
