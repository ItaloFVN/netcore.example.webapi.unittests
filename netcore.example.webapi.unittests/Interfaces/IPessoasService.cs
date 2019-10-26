using netcore.example.webapi.unittests.Models;
using System.Collections.Generic;

namespace netcore.example.webapi.unittests.Services
{
    public interface IPessoasService
    {
        IEnumerable<IPessoa> GetAll();

        IEnumerable<IPessoa> GetByName(string term);
    }
}
