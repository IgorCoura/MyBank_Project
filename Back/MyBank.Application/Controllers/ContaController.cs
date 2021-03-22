using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using System;

namespace MyBank.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ContaController : ControllerBase
    {
        private readonly IServiceConta _serviceConta;

        public ContaController(IServiceConta serviceConta)
        {
            _serviceConta = serviceConta;
        }

        [HttpPost("Register")]        
        public IActionResult CreateConta([FromBody] TokenModel contaModel)
        {
            try
            {
                var conta = _serviceConta.insert(contaModel);
                return Created($"/api/Cadastro/{conta.Id}", conta.Id);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("Recover")]
        public IActionResult Recover()
        {
            try
            {
                var conta = _serviceConta.Recover();
                return Ok(conta);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("RecoverAll")]
        public IActionResult RecoverAll()
        {
            try
            {
                var contas = _serviceConta.Recover();
                return Ok(contas);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
