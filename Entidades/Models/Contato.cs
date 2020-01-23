using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Models
{
    public class Contato
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
