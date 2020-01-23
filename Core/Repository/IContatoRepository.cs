using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Repository
{
    public interface IContatoRepository: IDisposable
    {
        IEnumerable<Contato> ToList();
        Contato GetByID(int Id);
        void Insert(Contato student);
        void Delete(int id);
        void Update(Contato contato);
        void Save();
    }
}