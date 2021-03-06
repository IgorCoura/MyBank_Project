using MyBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Interfaces
{
    public interface IServiceConta
    {
        public bool insert(CreateContaModel createConta);
        public IEnumerable<ReturnContaModel> Recover();
    }
}
