using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyBank.Domain.Entities;
using MyBank.Domain.Interfaces;
using MyBank.Domain.Models;
using MyBank.Infra.Shared.Mapper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyBank.Service.Services
{
    public class ClienteService : IServiceCliente
    {
        private readonly IRepositoryCliente _repositoryCliente;
        private readonly IConfiguration _configuration;

        //TODO: add Update cliente

        public ClienteService(IRepositoryCliente repositoryCliente, IConfiguration configuration)
        {
            this._repositoryCliente = repositoryCliente;
            _configuration = configuration;
        }

        public ClienteModel Insert(CreateClienteModel createCliente)
        {

            Cliente cliente = createCliente.ConvertToEntity();
            _repositoryCliente.Save(cliente);
            return cliente.ConvertToModel();

        }

        public IEnumerable<ClienteModel> RecoverAll()
        {
            var cliente = _repositoryCliente.Get();
            return cliente.ConvertToModel();
        }

        public ClienteModel Recover(int id)
        {
            return _repositoryCliente.Get(id).ConvertToModel();
        }
        

        public RespostaLoginModel Login(string cpf, string senha)
        {
            var cliente = _repositoryCliente.Get(cpf, senha);
            var expires = DateTime.UtcNow.AddMinutes(60);
            if (cliente != null)
            {
                var secret = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfigurations:Secret").Value);
                var symmetricSecurityKey = new SymmetricSecurityKey(secret);
                var securityTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.NameIdentifier, cpf.ToString()),
                        new Claim(ClaimTypes.Role, "Cliente") }),
                    Expires = expires,
                    SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                };
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
                var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated).ToString();
                cliente.Token = token;
                cliente.ExpirationToken = expires;
                _repositoryCliente.Save(cliente);
                return new RespostaLoginModel(true, "Acesso autorizado", expires, token, cliente.Nome);
            }

            return new RespostaLoginModel(false, "Acesso negado");
        }

        public void Delete(int id)
        {
            _repositoryCliente.Remove(id);
        }


    }
}
