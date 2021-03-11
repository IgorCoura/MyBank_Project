using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Models
{
    public class LoginModel
    {
        public LoginModel(string cPF, string senha)
        {
            CPF = cPF;
            Senha = senha;
        }

        public string CPF { get; set; }
        public string Senha { get; set; }
    }
}
