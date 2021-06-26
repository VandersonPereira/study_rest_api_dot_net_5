using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuatroVerbos.Models
{
    public class Pessoa
    {
        public long Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public long Endereco { get; set; }
        public long Genero { get; set; }
    }
}
