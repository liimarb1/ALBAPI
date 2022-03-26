using EFCore.WebAPI.Dominio;
using EFCore.WebAPI.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly ITContext _context;
        public ValuesController(ITContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
        {
            var listFuncionario = _context.Funcionarios
                .Where(f => EF.Functions.Like(f.Nome, $"%{nome}%"))
                .OrderByDescending(f => f.Id)
                .LastOrDefault();
            //var listFuncionario = (from funcionario in _context.Funcionarios
            //                       where funcionario.Nome.Contains(nome)
            //                       select funcionario).ToList();
            return Ok(listFuncionario);
        }
        

        // GET api/values/5
        [HttpGet("Atualizar/{nameFunc}")]
        public ActionResult<string> Get(string nameFunc)
        {
            //var funcionario = new Funcionario { Nome = nameFunc };

            var funcionario = _context.Funcionarios
                                    .Where(f => f.Id == 4)
                                     .FirstOrDefault();
            funcionario.Nome = "Sergio";

                 //_context.Funcionarios.Add(funcionario);
            _context.SaveChanges();

            return Ok();
        }

        // GET api/values/5
        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {

            _context.AddRange(

                new Funcionario { Nome = "Vitor" },
                new Funcionario { Nome = "Thiago" },
                new Funcionario { Nome = "Vivian" }

                );

            _context.SaveChanges();

            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpGet("Delete/{id}")]
        public void Delete(int id)
        {
            var funcionario = _context.Funcionarios
                                .Where(x => x.Id == id)
                                .Single();

            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();
        }
    }
}
