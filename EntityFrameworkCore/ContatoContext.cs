using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore
{
    public class ContatoContext : DbContext
    {
        private string conectionStringPadao => @"Server=(localdb)\mssqllocaldb;Database=ListaDeContatos;Integrated Security=True";
        private string _conectionString;
        public ContatoContext(DbContextOptions<ContatoContext> options) : base(options)
        {
        }

        public ContatoContext()
        {
            _conectionString = conectionStringPadao;
        }
        public ContatoContext(string conectionsString)
        {
            _conectionString = conectionsString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(_conectionString ?? conectionStringPadao);
        }

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
    }
}
