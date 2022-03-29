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

        //se for readonly ele nao precisa retornar entao apaga o get/set
        public readonly ITContext _context;

        //construtor recebe o contexto
        public ValuesController(ITContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
        {

            //lambida expression --  .Where(f => f.Nome.Contains(nome))
            //Metodo LinQ Method
            //usando o .ToList() ele fecha conexão e pode travar o banco


            var listFuncionario = _context.Funcionarios
                .Where(f => EF.Functions.Like(f.Nome, $"%{nome}%"))
                .OrderByDescending(f => f.Id)  //OrderBy = ordernar de forma crescente , orderbyDescending = ordenar de forma descrecente do ultimo para o primeiro
                            .SingleOrDefault();  //SingleOrDefault mostra o 1 da lista 
                                                 //O LastOrDefault mostra o ultimo da lista  


            //"dado funcionario selecione pra mim no contexto o funcionario"
            //Metodo LinQ Query
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

            //Where = retornei o func onde o Id fosse == "numero Id"
            //FirstOrDefault = se retornar pra mim uma lista retorna pra mim o primeiro ou o padrão

            var funcionario = _context.Funcionarios
                                    .Where(f => f.Id == 4)
                                     .FirstOrDefault(); //Fecha a conexão e te retorna o primeiro da lista 
            funcionario.Nome = "Sergio";

            //dessa maneira eu estou explicitando quem eu estou adicionando
            //contexto.Funcionarios.Add(funcionario);

            //e dessa maneira eu nao preciso explicitar
            //_context.Add(funcionario);

            //_context.Funcionarios.Add(funcionario);
            _context.SaveChanges();

            return Ok();
        }

        // GET api/values/5
        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            //AddRange adiciona varios objetos de um tipo "funcionario" que ele ja conhece, só de colocar "new Funcionario" ele ja sabe em qual tabela adicionar

            _context.AddRange(

                new Funcionario { Nome = "Vitor" },
                new Funcionario { Nome = "Thiago" },
                new Funcionario { Nome = "Vivian" }

                );
            //var funcionario = new Funcionario { Nome = nameFunc };

            //Where = retornei o func onde o Id fosse == "numero Id"
            //FirstOrDefault = se retornar pra mim uma lista retorna pra mim o primeiro ou o padrão

            var funcionario = _context.Funcionarios
                           .Where(f => f.Id == 5)
                           .FirstOrDefault();

            funcionario.Nome = "Lima";

            //dessa maneira eu estou explicitando quem eu estou adicionando
            //contexto.Funcionarios.Add(funcionario);

            //e dessa maneira eu nao preciso explicitar
            //_context.Add(funcionario);

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

            //passa o contexto no caso "funcionario" dentro do "Remove" como parametro

            _context.SaveChanges();
        }
    }
}
