using EFCore.WebAPI.Dominio;
using EFCore.WebAPI.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly ITContext _context;

        public FuncionarioController(ITContext context)
        {
            _context = context;
        }
        // GET: api/Funcionario
        [HttpGet]
        public ActionResult Get()
        {

            //usando try catch para simplificar

            try
            {
                return Ok(new Funcionario());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

        }

        // GET: api/Funcionario/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            return Ok("Value");
        }


        // POST: api/Funcionario
        [HttpPost]
        public ActionResult Post(Funcionario model)
        {
            try
            {
                _context.Funcionarios.Add(model);

                _context.SaveChanges();


                return Ok("Adicionado com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

            // PUT: api/Funcionario/5
            [HttpPut("{id}")]
            public ActionResult Put(int id, Funcionario model)
            {

            // Utilizando o Funcionarios eu utilizo o AsNoTracking, ele não deixa travar ou ficar atracado
            //o FirstOrDefault e dentro voce faz a sua clausula de Where first ou last
            try
            {
                if (_context.Funcionarios.AsNoTracking().FirstOrDefault(f => f.Id == id) != null)
                {
                    _context.Update(model);
                    _context.SaveChanges();

                    return Ok("Adicionado com Sucesso!");

                    //var funcionario = new Funcionario
                    //{


                    //    //Quando um ID é atribuido a um objeto nós estamos vinculando aquele objeto ao que existe no banco de dados
                    //    //Posso passar o _context.Funcionario.Update ou somente _context.Update porque o objeto/entidade está definido no contexto

                    //    Id = id,
                    //    Nome = "Fernando",
                    //    Equipamentos = new List<Equipamento>
                    //    {
                    //        new Equipamento { Id = 1, Nome = "Notebook Dell 1"},
                    //        new Equipamento { Id = 2, Nome = "Smartphone Samsung 1"}


                    //    }
                    //};
                }
                return Ok("Não adicionado!");
             }

                catch (Exception ex)
                {
                    return BadRequest($"Erro: {ex}");
                }
            }
        }
    }
