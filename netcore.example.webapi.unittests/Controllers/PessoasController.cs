using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using netcore.example.webapi.unittests.Models;
using netcore.example.webapi.unittests.Services;

namespace netcore.example.webapi.unittests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoasService _pessoasService;

        public PessoasController(IPessoasService pessoasService)
        {
            _pessoasService = pessoasService;
        }

        [HttpGet]
        public IEnumerable<IPessoa> GetByName([FromQuery] string term)
        {
            return term == null ? _pessoasService.GetAll() : _pessoasService.GetByName(term);
        }
    }
}
