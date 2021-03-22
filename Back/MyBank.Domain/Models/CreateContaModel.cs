using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Models
{
    public class CreateContaModel
    {
        public string token { get; set; }

        public CreateContaModel(string token)
        {
            this.token = token;
        }
    }
}
