using AutoMapper;
using Patrimonios.Entidade;
using Patrimonios.Models;
using Patrimonios.Repositorio.Interfaces;
using Patrimonios.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Services.Impl
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepositorio Repositorio;
        private IMapper Mapper;
        public UsuarioService(IUsuarioRepositorio repo, IMapper mapper)
        {
            Repositorio = repo;
            Mapper = mapper;
        }
        public UsuarioViewModel EditarUsuario(UsuarioViewModel usuario)
        {
            ValidarEmail(usuario.Id, usuario.Email);
            var entidade = Mapper.Map<Usuario>(usuario);
            Repositorio.Save(entidade);
            return Mapper.Map<UsuarioViewModel>(entidade);
        }

        public UsuarioViewModel InserirUsuario(UsuarioViewModel usuario)
        {
            ValidarEmail(usuario.Id, usuario.Email);
            var entidade = Mapper.Map<Usuario>(usuario);
            Repositorio.Save(entidade);
            return Mapper.Map<UsuarioViewModel>(entidade);
        }

        public List<UsuarioViewModel> ListarUsuarios()
        {
            var entidade = Repositorio.ListAll();
            return Mapper.Map<List<UsuarioViewModel>>(entidade);
        }

        public UsuarioViewModel ObterUsuario(int id)
        {
            var entidade = Repositorio.Get(id);
            return Mapper.Map<UsuarioViewModel>(entidade);

        }

        public bool RemoveUsuario(int id)
        {
            var entidade = Repositorio.Get(id);
            if (entidade != null)
            {
                Repositorio.Remove(entidade);
                return true;
            }
            return false;
        }
        private void ValidarEmail(int id,string email)
        {
            var usuario = Repositorio.Get(x => x.Email.ToLowerInvariant().Equals(email.ToLowerInvariant()));
            if ((usuario != null && usuario.Id != id) || (usuario != null && id ==0))
            {
                throw new Exception($"Email {email} cadastrado");
            }
        }
    }
}
