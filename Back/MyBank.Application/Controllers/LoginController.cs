using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using System;

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
                ReturnLoginModel resp = _serviceCliente.Login(req);

                if (resp.Authorization)
                {
                    return Ok(resp);
                }
                else
                {
                    return Unauthorized(resp);
                }
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
                           
            
        }
    }
}
