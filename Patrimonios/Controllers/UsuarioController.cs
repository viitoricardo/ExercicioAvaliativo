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
    public class UsuarioController : ControllerBase
    {
        IUsuarioService Service;

        public UsuarioController (IUsuarioService service)
        {
            Service = service;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        
        public IEnumerable<UsuarioViewModel> Get()
        {
            return Service.ListarUsuarios();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public UsuarioViewModel Get(int id)
        {
            return Service.ObterUsuario(id);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        [AllowAnonymous]
        public UsuarioViewModel Post([FromBody] UsuarioViewModel usuario)
        {
            return Service.InserirUsuario(usuario);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public UsuarioViewModel Put(int id, [FromBody] UsuarioViewModel usuario)
        {
            usuario.Id = id;
            return Service.EditarUsuario(usuario);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return Service.RemoveUsuario(id);
        }
    }
}
