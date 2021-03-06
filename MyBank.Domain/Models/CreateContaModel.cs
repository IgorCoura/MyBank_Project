using MyBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Models
{
    public class CreateContaModel
    {
        public CreateContaModel(Cliente cliente, int agencia, int numConta, string senha)
        {
            Cliente = cliente;
            Agencia = agencia;
            NumConta = numConta;
            Senha = senha;
        }

        public Cliente Cliente { get; set; }
        public int Agencia { get; set; }
        public int NumConta { get; set; }
        public string Senha { get; set; }
    }
}
