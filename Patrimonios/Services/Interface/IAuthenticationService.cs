using Patrimonios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Services.Interface
{
    public interface IAuthenticationService
    {
        AuthViewModel Autenticar(AuthViewModel auth);
            
    }
}
