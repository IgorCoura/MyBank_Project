using Microsoft.AspNetCore.Mvc;
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
    public class ClienteController : Controller
    {
        private readonly IServiceCliente _serviceCliente;

        public ClienteController(IServiceCliente serviceCliente)
        {
            _serviceCliente = serviceCliente;
        }

        [HttpPost]
        public IActionResult RegisterCliente([FromBody] CreateClienteModel clienteModel)
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

    }
}
