using System;
using System.Collections.Generic;

namespace MyBank.Domain.Entities
{
    public class Cliente: BaseEntity<int>
    {
        private Cliente() { }

        public Cliente(int id, string nome, string cpf, string dataNascimento, string senha): base(id)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Senha = senha;
        }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationToken { get; set; }
        public virtual IList<Conta> Conta { get; set; }


    }
}
