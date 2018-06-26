using System;
using System.Collections.Generic;
using Welo.Domain.Entities.Base;

namespace Welo.Domain.Entities
{
    [Serializable]
    public class FilmeEntity : Entity<int>
    {
        public string Nome { get; set; }
        public int Ano { get; set; }
        public IEnumerable<string> Genero { get; set; }
    }
}
