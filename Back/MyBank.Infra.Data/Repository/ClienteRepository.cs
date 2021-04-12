using Aurora.Domain.ValueTypes;
using MyBank.Domain.Entities;
using MyBank.Domain.Interfaces;
using MyBank.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace MyBank.Infra.Data.Repository
{
    public class ClienteRepository : BaseRepository<Cliente, int>, IRepositoryCliente
    {
        public ClienteRepository(SqlServerContext sqlContext) : base(sqlContext)
        {
        }

        public void Remove(int id)
        {
            base.Delete(x => x.Id == id);
        }

        public void Save(Cliente obj)
        {
            
            if(obj.Id == 0)
            {
                base.Insert(obj);
            }
            else
            {
                base.Update(obj);
            }            
        }

        public Cliente Get(int id) => base.Select(x => x.Id == id);
        public Cliente Get(CPF cpf, string senha) => base.Select(x => x.CPF == cpf && x.Senha == senha);
        public Cliente Get(string token) {
            var timeNow = DateTime.UtcNow;
            return base.Select(x => x.Token == token && x.ExpirationToken > timeNow); 
        }
        public IList<Cliente> Get() => base.SelectList();
             
    }
}
