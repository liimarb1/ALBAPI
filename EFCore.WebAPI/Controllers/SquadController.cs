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
    public class SquadController : ControllerBase
    {
        private readonly ITContext _context;

        public SquadController(ITContext context)
        {
            _context = context;
        }
        // GET: api/squad
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Squad());
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

        }

        // GET: api/squad/5
        [HttpGet("{id}", Name = "GetSquad")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }


        // POST: api/squad
        [HttpPost]
        public ActionResult Post(Squad model)
        {
            try
            {
                _context.Squads.Add(model);
                _context.SaveChanges();

                return Ok("Adicionado com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/squad/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Squad model)
        {
            try
            {
                if (_context.Squads.AsNoTracking().FirstOrDefault(f => f.Id == id) != null)
                    _context.Update(model);
                _context.SaveChanges();

                return Ok("Adicionado com Sucesso!");



                return Ok("Não encotrado!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

        }
    }
}
