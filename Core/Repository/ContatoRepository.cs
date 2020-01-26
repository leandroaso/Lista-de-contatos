using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Entidades.Models;
using EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository
{
    public class ContatoRepository : IContatoRepository, IDisposable
    {
        private readonly ContatoContext _context;

        public ContatoRepository(ContatoContext context)
        {
            this._context = context;
        }

        public IEnumerable<Contato> ToList()
        {
            return _context.Contatos.ToList();
        }

        public Contato GetByID(long id)
        {
            return _context.Contatos.Find(id);
        }

        public IEnumerable<Contato> Get(string nome, string cpf)
        {
            IQueryable<Contato> query = _context.Contatos;

            if (!string.IsNullOrWhiteSpace(cpf))
                query = query.Where(c => c.CPF == cpf);

            if (!string.IsNullOrWhiteSpace(nome))
                query = query.Where(c => c.Nome.Contains(nome));

            return query.AsEnumerable();
        }

        public void Insert(Contato student)
        {
            _context.Contatos.Add(student);
        }

        public void Delete(long id)
        {
            Contato contato = _context.Contatos.Find(id);
            _context.Contatos.Remove(contato);
        }

        public void Update(Contato contato)
        {
            var contatoAtualizado = GetByID(contato.Id);

            if (contatoAtualizado.Telefones != null)
                foreach (var telefone in contatoAtualizado.Telefones)
                    _context.Entry(telefone).State = EntityState.Deleted;

            if (contato.Telefones != null)
                foreach (var telefone in contato.Telefones)
                    contatoAtualizado.Telefones.Add(telefone);

            contatoAtualizado.Nome = contato.Nome;
            contatoAtualizado.CPF = contato.CPF;
            contatoAtualizado.DataNascimento = contato.DataNascimento;
            contatoAtualizado.Email = contato.Email;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
