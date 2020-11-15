using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Models
{
    public class AuthViewModel
    {
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Erro { get; set; }
    }
}
