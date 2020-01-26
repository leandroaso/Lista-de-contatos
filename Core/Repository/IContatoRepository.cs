using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Repository
{
    public interface IContatoRepository: IDisposable
    {
        IEnumerable<Contato> ToList();
        IEnumerable<Contato> Get(string nome, string cpf);
        Contato GetByID(long Id);
        void Insert(Contato student);
        void Delete(long id);
        void Update(Contato contato);
        void Save();
    }
}