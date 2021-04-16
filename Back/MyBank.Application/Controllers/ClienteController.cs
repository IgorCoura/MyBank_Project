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
    public class ClienteController : Controller
    {
        private readonly IServiceCliente _serviceCliente;

        public ClienteController(IServiceCliente serviceCliente)
        {
            _serviceCliente = serviceCliente;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult RegisterCliente([FromBody]CreateClienteModel clienteModel)
        {
            try
            {
                var cliente = _serviceCliente.Insert(clienteModel);
                return Created($"/api/Cadastro/{cliente.Id}", cliente.Id);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("RecoverByToken")]
        public IActionResult Recover(string token)
        {
            try
            {
                var cliente = _serviceCliente.Recover(new TokenModel(token));
                return Ok(cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
