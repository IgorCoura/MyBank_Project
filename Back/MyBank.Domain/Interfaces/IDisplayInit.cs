using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Interfaces
{
    public interface IDisplayInit
    {
        public bool AcessarConta();
        public bool Cadastro();
        public void Init();
    }
}
