using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Patrimonios.Services.Interface;

namespace Patrimonios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Exercicio1Controller : Controller
    {
        IExercio1Service Service;
        public Exercicio1Controller (IExercio1Service service)
        {
            Service = service;
        }

        [HttpGet("{n}")]
        public int Teste(int n)
        {
            
            return Service.ObterMaiorNumeroIrmao(n);
        }

    }
}
