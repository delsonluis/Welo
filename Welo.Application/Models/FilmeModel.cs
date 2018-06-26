using System.Collections.Generic;

namespace Welo.Application.Models
{
    public class FilmeModel
    {
        public string Nome { get; set; }
        public int Ano { get; set; }
        public IEnumerable<string> Genero { get; set; }
    }
}
