using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welo.Domain.Entities;

namespace Welo.Application.Interfaces
{
    public interface IFilmeAppService : IAppServiceBase<FilmeEntity, int>
    {
    }
}
