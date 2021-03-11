using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyBank.Domain.Entities;
using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceConta _serviceConta;
        private readonly IServiceCliente _serviceCliente;

        public LoginController(IConfiguration configuration, IServiceConta serviceConta, IServiceCliente serviceCliente)
        {
            _configuration = configuration;
            _serviceConta = serviceConta;
            _serviceCliente = serviceCliente;
        }

        [HttpPost]
        public IActionResult RequestToken([FromBody] LoginModel req)
        {
            try
            {
                teste t = new teste(_serviceCliente, _serviceConta);
                t.createContas();
                var expires = DateTime.UtcNow.AddMinutes(1);
                ReturnContaModel conta = null;
                var cliente = _serviceCliente.Recover(req.CPF);
                if (cliente != null)
                {
                    conta = _serviceConta.Login(cliente.Id, req.Senha);
                }

                if (conta != null)
                {
                    var secret = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfigurations:Secret").Value);
                    var symmetricSecurityKey = new SymmetricSecurityKey(secret);
                    var securityTokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, req.CPF.ToString()),
                    new Claim(ClaimTypes.Role, "Cliente") }),
                        Expires = expires,
                        SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                    };
                    var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                    var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
                    var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated).ToString();

                    return Ok(new RespostaLoginModel(true, "Acesso autorizado", expires, token, conta.Cliente.Nome));
                }
                else
                {
                    return Unauthorized(new RespostaLoginModel(false, "Acesso negado"));
                }
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
                           
            
        }
    }
}
