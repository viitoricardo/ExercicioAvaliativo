using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Patrimonios.Models;
using Patrimonios.Services.Interface;

namespace Patrimonios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        IAuthenticationService Service;
        public AuthController(IAuthenticationService service)
        {
            Service = service;
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public AuthViewModel Post([FromBody] AuthViewModel usuario)
        {
            return Service.Autenticar(usuario);
        }
    }
}
