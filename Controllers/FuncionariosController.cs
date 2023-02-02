using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi_security.Context;
using webapi_security.Dto;
using webapi_security.Models;
using webapi_security.Services;

namespace webapi_security.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class FuncionariosController : ControllerBase
    {
        private readonly RhContext _context;

        public FuncionariosController(RhContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcionario>>> Get()
        {
            return _context.Funcionarios.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> Get(int id)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return funcionario;
        }

        [HttpPost]
        public async Task<ActionResult<Funcionario>> Post([FromBody] Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
            return funcionario;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Funcionario>> Put(int id, [FromBody] Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return BadRequest();
            }

            _context.Entry(funcionario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return funcionario;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Funcionario>> Delete(int id)
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();
            return funcionario;
        }
        
    }
}