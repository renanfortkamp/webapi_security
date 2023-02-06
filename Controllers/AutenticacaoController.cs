using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [Route("api/login")]
    [AllowAnonymous]
    public class AutenticacaoController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        private readonly RhContext _context;

        public AutenticacaoController(RhContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> AutenticacaoAsync([FromBody] FuncionarioDto dto)
        {
            var funcionario = await _context.Funcionarios
                .Include(x => x.Permissao)
                .FirstOrDefaultAsync(x => x.Email == dto.Email && x.Senha == dto.Senha);
            if (funcionario == null)
            {
                return NotFound(new { message = "Usuário não encontrado" });
            }

            var token = _tokenService.GerarToken(funcionario);
            return Ok(token);

            //ssss
        }
    }
}
