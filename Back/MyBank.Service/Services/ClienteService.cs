using Aurora.Domain.ValueTypes;
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
        private readonly IRepositoryConta _repositoryConta;
        private readonly IConfiguration _configuration;

        public ClienteService(IRepositoryCliente repositoryCliente, IConfiguration configuration, IRepositoryConta repositoryConta)
        {
            _repositoryCliente = repositoryCliente;
            _configuration = configuration;
            _repositoryConta = repositoryConta;
        }

        public ClienteModel Insert(CreateClienteModel createCliente)
        {

            Cliente cliente = createCliente.ConvertToEntity();
            _repositoryCliente.Save(cliente);
            return cliente.ConvertToModel();

        }

        public ClienteModel Recover(TokenModel token)
        {
           var cliente = _repositoryCliente.Get(token.token);
           var clienteModel = cliente.ConvertToModel();
           clienteModel.ContaModel = (IList<ReturnContaModel>)_repositoryConta.GetList(cliente.Id).ConvertToReturnModel();
           return clienteModel;
        }        

        public ReturnLoginModel Login(LoginModel loginModel)
        {
            CPF cpf = loginModel.CPF;
            var cliente = _repositoryCliente.Get(cpf, loginModel.Senha);
            var expires = DateTime.UtcNow.AddMinutes(60);
            if (cliente != null)
            {
                var secret = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfigurations:Secret").Value);
                var symmetricSecurityKey = new SymmetricSecurityKey(secret);
                var securityTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.NameIdentifier, loginModel.CPF.ToString()),
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
                return new ReturnLoginModel(true, "Acesso autorizado", expires, token, cliente.Nome);
            }

            return new ReturnLoginModel(false, "Acesso negado");
        }


    }
}
