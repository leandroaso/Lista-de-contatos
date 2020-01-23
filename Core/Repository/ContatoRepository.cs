using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Models;
using EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository
{
    public class ContatoRepository : IContatoRepository, IDisposable
    {
        private ContatoContext context;

        public ContatoRepository(ContatoContext context)
        {
            this.context = context;
        }

        public IEnumerable<Contato> ToList()
        {
            return context.Contatos.ToList();
        }

        public Contato GetByID(int id)
        {
            return context.Contatos.Find(id);
        }

        public void Insert(Contato student)
        {
            context.Contatos.Add(student);
        }

        public void Delete(int id)
        {
            Contato contato = context.Contatos.Find(id);
            context.Contatos.Remove(contato);
        }

        public void Update(Contato contato)
        {
            context.Entry(contato).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
