using Core.Repository;
using Entidades.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Core.Test
{
    public class TesteInsert
    {
        public ContatoRepository _repository { get; set; }
        public TesteInsert()
        {
            _repository = new ContatoRepository(new EntityFrameworkCore.ContatoContext());
        }

        [Fact]
        public void DeveSalvarContatoSemErro()
        {
            var contato = new Contato { 
                CPF = "85858585858",
                DataNascimento = DateTime.Now.AddYears(-18),
                Email ="teste@teste.com",
                Nome = "Leandro teste",
                Telefones = new List<Telefone>()
                {
                    new Telefone
                    {
                        DDD = "85",
                        Numero ="8585858599"
                    }
                }
            };

            _repository.Insert(contato);
            _repository.Save();
        }
    }
}
