using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Fixbi.Domains;
using Fixbi.Interfaces;
using Fixbi.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Fixbi.ViewModels;
using System.Text;

namespace Fixbi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Logar(LoginViewModel login)
        {
            try
            {
                Usuarios usuarioProcurado = UsuarioRepository.BuscarPorEmailESenha(login);

                if (usuarioProcurado == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Usuário ou senha encontrados"
                    });
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioProcurado.EmailUsuario),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioProcurado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioProcurado.IdTipoUsuarioNavigation.TipoUsuario),
                    new Claim("Role", usuarioProcurado.IdTipoUsuarioNavigation.TipoUsuario)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Aplicativo.Fixbi"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: "Fixbi",
                    audience: "Fixbi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }
    }
}