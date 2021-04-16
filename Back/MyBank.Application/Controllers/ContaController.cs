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

        [HttpPatch("Sacar")]
        public IActionResult SacarConta([FromBody] TransacaoContaModel contaModel)
        {
            try
            {
                _serviceConta.sacar(contaModel);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPatch("Depositar")]
        public IActionResult DepositarConta([FromBody] TransacaoContaModel contaModel)
        {
            try
            {
                _serviceConta.depositar(contaModel);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPatch("Transferir")]
        public IActionResult TransferirConta([FromBody] TransferenciaContaModel contaModel)
        {
            try
            {
                _serviceConta.transferir(contaModel);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("Deletar")]
        public IActionResult RemoveConta([FromBody] ContaModel contaModel)
        {
            try
            {
                _serviceConta.delete(contaModel);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
