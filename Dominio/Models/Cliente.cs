using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Cliente :BaseEntity
    {
        public string NomeCompleto { get; set; }
        public DateTime DataNasc { get; set; }
        public int Documento { get; set; }
        public string Endereco { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

    }
}
