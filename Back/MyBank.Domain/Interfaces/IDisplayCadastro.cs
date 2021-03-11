using MyBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Interfaces
{
    public interface IDisplayCadastro
    {
        public Cliente NovoCliete();
        public bool NovaConta(Cliente cliente = null);
    }
}
