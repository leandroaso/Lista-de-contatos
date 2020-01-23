using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
        public long ContatoId { get; set; }
        public virtual Contato Contato { get; set; }
    }
}
