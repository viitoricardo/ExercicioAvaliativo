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
    public class MarcaController : ControllerBase
    {
        IMarcaService Service;
        
        public MarcaController (IMarcaService service)
        {
            Service = service;
        }
        
        // GET: api/<MarcaController>
        [HttpGet]
        public IEnumerable<MarcaViewModel> Get()
        {
            return Service.ListarMarcas();
        }

        // GET api/<MarcaController>/5
        [HttpGet("{id}")]
        public MarcaViewModel Get(int id)
        {
            return Service.ObterMarca(id);
        }

        // POST api/<MarcaController>
        [HttpPost]
        public MarcaViewModel Post([FromBody] MarcaViewModel marca)
        {
            return Service.InserirMarca(marca);
        }

        // PUT api/<MarcaController>/5
        [HttpPut("{id}")]
        public MarcaViewModel Put(int id, [FromBody] MarcaViewModel marca)
        {
            marca.Id = id;
            return Service.EditarMarca(marca);
        }

        // DELETE api/<MarcaController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return Service.RemoveMarca(id);
        }
    }
}
