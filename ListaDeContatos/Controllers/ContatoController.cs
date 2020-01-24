using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Repository;
using Entidades.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeContatos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _repository;
        public ContatoController(IContatoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Contato> Get()
        {
            var result = _repository.ToList();
            return result;
        }

        [HttpGet("{id}", Name = "Get")]
        public Contato Get(int id)
        {
            return _repository.GetByID(id);
        }

        [HttpPost]
        public void Post([FromBody] Contato contato)
        {
            _repository.Insert(contato);
            _repository.Save();
        }

        [HttpPut]
        public void Put([FromBody] Contato contato)
        {
            _repository.Update(contato);
            _repository.Save();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}
