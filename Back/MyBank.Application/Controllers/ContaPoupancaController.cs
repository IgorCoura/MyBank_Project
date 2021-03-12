using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBank.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContaPoupancaController : ControllerBase
    {
        private readonly IServiceContaPoupanca _serviceConta;

        public ContaPoupancaController(IServiceContaPoupanca serviceConta)
        {
            _serviceConta = serviceConta;
        }

        [HttpPost]
        [Authorize]
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
        

        [HttpGet]
        public IActionResult RecoverAll()
        {
            try
            {
                var contas = _serviceConta.Recover();
                return Ok(contas);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
