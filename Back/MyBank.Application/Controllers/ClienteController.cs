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

        [HttpGet]
        public IActionResult RecoverAll()
        {
            try
            {
                var clientes = _serviceCliente.RecoverAll();
                return Ok(clientes);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
