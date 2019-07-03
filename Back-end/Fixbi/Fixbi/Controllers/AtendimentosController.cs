using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Fixbi.Domains;
using Fixbi.Interfaces;
using Fixbi.Repositories;

namespace Fixbi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AtendimentosController : ControllerBase
    {
        private IAtendimentoRepository AtendimentoRepository { get; set; }

        public AtendimentosController()
        {
            AtendimentoRepository = new AtendimentoRepository();

        }

        [HttpPost("cadastrar")]
        [Authorize(Roles = "Ciclista, Mecanico")]
        public IActionResult cadastrarAtendimento(Atendimentos atendimento)
        {
            try
            {
                AtendimentoRepository.cadastrarAtendimento(atendimento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpGet("listar")]
        [Authorize(Roles = "Ciclista, Mecanico")]
        public IActionResult listarAtendimentos()
        {
            try
            {
                return Ok(AtendimentoRepository.todosAtendimentos());
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}