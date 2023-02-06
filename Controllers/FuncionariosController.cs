using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private readonly IMapper _mapper;

        public FuncionariosController(RhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        [Authorize(Roles = ("Funcionario, Gerente, Administrador"))]
        public async Task<ActionResult<IEnumerable<Funcionario>>> Get()
        {
            try
            {
                var funcionarios = await _context.Funcionarios.ToListAsync();
                if (User.IsInRole("Funcionario"))
                {
                    var funcionariosMapeados = _mapper.Map<List<NomePermissao>>(funcionarios);

                    return Ok(funcionariosMapeados);
                }
                else
                {
                    var funcionariosMapeados = _mapper.Map<List<FuncionarioRequest>>(funcionarios);
                    return Ok(funcionariosMapeados);
                }
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor, tente novamente mais tarde");
            }
        }

        [HttpGet("Buscar/{id}")]
        [Authorize(Roles = ("Funcionario, Gerente, Administrador"))]
        public async Task<ActionResult<Funcionario>> Get(int id)
        {
            try
            {
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);
                if (funcionario == null)
                {
                    return NotFound("Funcionario não encontrado!");
                }
                if (User.IsInRole("Funcionario"))
                {
                    var funcionarioMapeado = _mapper.Map<NomePermissao>(funcionario);

                    return Ok(funcionarioMapeado);
                }
                var funcionarioMap = _mapper.Map<FuncionarioRequest>(funcionario);
                return Ok(funcionarioMap);
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor, tente novamente mais tarde");
            }
        }

        [HttpPost("Cadastrar")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult<Funcionario>> Post([FromBody] FuncionarioRequest funcionario)
        {
            try
            {
                var funcionarioEntity = _mapper.Map<Funcionario>(funcionario);
                await _context.Funcionarios.AddAsync(funcionarioEntity);
                await _context.SaveChangesAsync();
                return funcionarioEntity;
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor, tente novamente mais tarde");
            }
        }

        [HttpPut("AlterarSalario/{id}")]
        [Authorize(Roles = ("Gerente"))]
        public async Task<ActionResult<AlterarSalario>> Put(
            int id,
            [FromBody] AlterarSalario funcionario
        )
        {
            try
            {
                var funcionarioEntity = await _context.Funcionarios.FirstOrDefaultAsync(
                    x => x.Id == id
                );
                if (funcionarioEntity == null)
                {
                    return NotFound();
                }

                funcionarioEntity.Salario = funcionario.Salario;

                _context.Entry(funcionarioEntity).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok($"Salário do funcionário {funcionarioEntity.Nome} alterado com sucesso!");
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor, tente novamente mais tarde");
            }
        }

        [HttpDelete("Deletar/{id}")]
        [Authorize(Roles = ("Gerente, Administrador"))]
        public async Task<ActionResult<Funcionario>> Delete(int id)
        {
            try
            {
                var funcionario = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);
                if (funcionario == null)
                {
                    return NotFound("Funcionario não encontrado!");
                }
                if (User.IsInRole("Gerente"))
                {
                    if (funcionario.PermissaoId == 3)
                    {
                        return BadRequest("Você não tem permissão para deletar um administrador!");
                    }
                }
                _context.Funcionarios.Remove(funcionario);
                _context.SaveChanges();
                return Ok($"Funcionario {funcionario.Nome} deletado com sucesso!");
            }
            catch
            {
                return StatusCode(500, "Erro interno no servidor, tente novamente mais tarde");
            }
        }
    }
}
