using Aurora.Domain.ValueTypes;
using MyBank.Domain.Entities;
using MyBank.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Infra.Data.Repository
{
    public class ClienteRepository : BaseRepository<Cliente, int>, IRepositoryCliente
    {
        //TODO: Integrar o repository cliente com o banco de dados

        //ClienteRepository()
        //{
        //    //Save();
        //}

        int newId = 1;
        public void Remove(int id)
        {
            base.Delete(x => x.Id == id);
        }

        public void Save(Cliente obj)
        {
            
            if(obj.Id == 0)
            {
                obj.Id = newId;
                newId++;
                base.Insert(obj);
            }
            else
            {
                base.Update(obj, x => x.Id == obj.Id);
            }            
        }

        public Cliente Get(int id) => base.Select(x => x.Id == id);
        public Cliente Get(CPF cpf) => base.Select(x => x.CPF.ToString() == cpf.ToString());

        public IList<Cliente> Get() => base.Select();
             
    }
}
