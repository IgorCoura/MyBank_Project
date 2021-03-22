using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Domain.Models
{
    public class TokenModel
    {
        public string token { get; set; }

        public TokenModel(string token)
        {
            this.token = token;
        }
    }
}
