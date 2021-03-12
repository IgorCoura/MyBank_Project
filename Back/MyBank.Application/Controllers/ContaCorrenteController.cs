using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBank.Application.Controllers;
using MyBank.Domain.Entities;
using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBank.Application.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IServiceContaCorrente _serviceConta;

        public ContaCorrenteController(IServiceContaCorrente serviceConta)
        {
            _serviceConta = serviceConta;
        }

        [HttpPost("Register")]        
        [AllowAnonymous]
        public IActionResult RegisterConta([FromBody] CreateContaModel contaModel)
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
        public IActionResult Recover([FromBody] ConsultaContaModel contaModel)
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

        [HttpPatch("Depositar")]        
        public IActionResult Depositar([FromBody] ConsultaContaModel contaModel)
        {
            try
            {
                _serviceConta.Depositar(contaModel);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPatch("Sacar")]
        public IActionResult Sacar([FromBody] ConsultaContaModel contaModel)
        {
            try
            {
                _serviceConta.Sacar(contaModel);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPatch("Transferir")]
        public IActionResult Transferir([FromBody] ConsultaContaModel contaModelOrigin, ConsultaContaModel contaModelDestiny)
        {
            try
            {
                _serviceConta.Transferir(contaModelOrigin, contaModelDestiny);
                return Ok();
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
