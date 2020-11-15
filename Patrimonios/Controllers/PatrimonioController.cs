using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Patrimonios.Models;
using Patrimonios.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Patrimonios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatrimonioController : ControllerBase
    {
        IPatrimonioService Service;

        public PatrimonioController(IPatrimonioService service) 
        {
            Service = service;
        }

        // GET: api/<PatrimonioController>
        [HttpGet]
        public IEnumerable<PatrimonioViewModel> Get()
        {
            return Service.ListarPatrimonios();
        }

        // GET api/<PatrimonioController>/5
        [HttpGet("{id}")]
        public PatrimonioViewModel Get(int id)
        {
            return Service.ObterPatrimonio(id);
        }

        // POST api/<PatrimonioController>
        [HttpPost]
        public PatrimonioViewModel Post([FromBody] PatrimonioEditViewModel patrimonio)
        {
            return Service.InserirPatrimonio(patrimonio);
        }

        // PUT api/<PatrimonioController>/5
        [HttpPut("{numeroTombo}")]
        public PatrimonioViewModel Put(int numeroTombo, [FromBody] PatrimonioEditViewModel patrimonio)
        {            
            return Service.EditarPatrimonio(numeroTombo, patrimonio);
        }

        // DELETE api/<PatrimonioController>/5
        [HttpDelete("{numeroTombo}")]
        public bool Delete(int numeroTombo)
        {
            return Service.RemovePatrimonio(numeroTombo);
        }
    }
}
