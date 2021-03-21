using MyBank.Domain.Entities;

namespace MyBank.Domain.Interfaces
{
    public interface IDisplayCadastro
    {
        public Cliente NovoCliete();
        public bool NovaConta(Cliente cliente = null);
    }
}
