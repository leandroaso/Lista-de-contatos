using Core.Repository;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Core.Test
{
    public class TesteRepository
    {
        private string conectionStringTeste => @"Server=(localdb)\mssqllocaldb;Database=ListaDeContatos;Integrated Security=True";
        private readonly EntityFrameworkCore.ContatoContext _context;
        private ContatoRepository _repository { get; set; }

        public TesteRepository()
        {
            _context = new EntityFrameworkCore.ContatoContext();
            _repository = new ContatoRepository(_context);

            PreparandoSenario();
        }

        [Fact]
        public void DeveSalvarContatoSemErro()
        {
            PreparandoSenario();

            var contato = new Contato
            {
                CPF = "85858585858",
                DataNascimento = DateTime.Now.AddYears(-18),
                Email = "teste@teste.com",
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

            Assert.True(contato.Id != null && contato.Id > 0);
        }

        [Fact]
        public void DeveAtualizarContatoSemErro()
        {
            PreparandoSenario();

            var idContato = salvandoContatoDeteste("leandro");
            var contato = _repository.GetByID(idContato);

            contato.Nome = "joao";

            _repository.Update(contato);
            _repository.Save();

            var contatoAtualizado = _repository.GetByID(idContato);

            Assert.True(contatoAtualizado.Nome == "joao");
        }

        [Fact]
        public void DeveBuscarContatoPorNomeCorretamente()
        {
            PreparandoSenario();

            var idContato = salvandoContatoDeteste("leandro", "12345678912");

            var listaContatos = _repository.Get("leandro", null);

            Assert.True(listaContatos.Count() == 1);
        }

        [Fact]
        public void DeveBuscarContatoPorCPFCorretamente()
        {
            PreparandoSenario();

            var idContato = salvandoContatoDeteste("leandro", "12345678912");

            var listaContatos = _repository.Get(null, "12345678912");

            Assert.True(listaContatos.Count() == 1);
        }

        [Fact]
        public void DeveDeletarContatoCorretamente()
        {
            PreparandoSenario();

            var idContato = salvandoContatoDeteste("leandro", "12345678912");

            _repository.Delete(idContato);
            _repository.Save();

            var contato = _repository.GetByID(idContato);

            Assert.True(contato == null);
        }

        private void PreparandoSenario()
        {
            _context.Contatos.RemoveRange(_context.Contatos.ToList());
            _context.SaveChanges();

            var listaDeContatos = new List<Contato>();

            for (int i = 0; i < 4; i++)
            {
                listaDeContatos.Add(new Contato
                {
                    CPF = $"{i}{i}{i}{i}{i}{i}",
                    DataNascimento = DateTime.Now.AddYears(-18),
                    Email = $"teste{i}@teste.com",
                    Nome = $"teste{i} teste",
                    Telefones = new List<Telefone>
                    {
                        new Telefone
                        {
                            DDD =$"0{i}",
                            Numero =$"{i}8585858585{i}"
                        }
                    }
                });
            }
        }

        private long salvandoContatoDeteste(string nome = "Leandro teste", string cpf = "85858585858")
        {
            var contato = new Contato
            {
                CPF = cpf,
                DataNascimento = DateTime.Now.AddYears(-18),
                Email = "teste@teste.com",
                Nome = nome,
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

            return contato.Id;
        }
    }
}
