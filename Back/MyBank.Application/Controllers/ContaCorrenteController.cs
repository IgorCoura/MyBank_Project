using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IServiceContaCorrente _serviceConta;

        public ContaCorrenteController(IServiceContaCorrente serviceConta)
        {
            _serviceConta = serviceConta;
        }

        [HttpPost]
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

    }
}
