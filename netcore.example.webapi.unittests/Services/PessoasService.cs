using System.Collections.Generic;
using System.Linq;
using netcore.example.webapi.unittests.Models;

namespace netcore.example.webapi.unittests.Services
{
    public class PessoasService : IPessoasService
    {
        private readonly List<PessoaDto> _pessoas = new List<PessoaDto>();
        public PessoasService()
        {
            _pessoas.Add(new PessoaDto() { Nome = "Marcelo" });
            _pessoas.Add(new PessoaDto() { Nome = "Marcos" });
            _pessoas.Add(new PessoaDto() { Nome = "Cristiane" });
        }
        public IEnumerable<IPessoa> GetAll()
        {
            return _pessoas.AsReadOnly();
        }

        public IEnumerable<IPessoa> GetByName(string term)
        {
            return _pessoas.Where(p => p.Nome.Contains(term)).ToList().AsReadOnly();
        }
    }
}
