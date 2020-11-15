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
    public class MarcaService : IMarcaService
    {
        private IMarcaRepositorio Repositorio;
        private IMapper Mapper;
        public MarcaService(IMarcaRepositorio repo, IMapper mapper)
        {
            Repositorio = repo;
            Mapper = mapper;
        }
        public MarcaViewModel EditarMarca(MarcaViewModel marca)
        {
            var entidade = Mapper.Map<Marca>(marca);
            Repositorio.Save(entidade);
            return Mapper.Map<MarcaViewModel>(entidade);
        }

        public MarcaViewModel InserirMarca(MarcaViewModel marca)
        {
            var entidade = Mapper.Map<Marca>(marca);
            Repositorio.Save(entidade);
            return Mapper.Map<MarcaViewModel>(entidade);
        }

        public List<MarcaViewModel> ListarMarcas()
        {
            var entidade = Repositorio.ListAll();
            return Mapper.Map<List<MarcaViewModel>>(entidade);
        }

        public MarcaViewModel ObterMarca(int id)
        {
            var entidade = Repositorio.Get(id);
            return Mapper.Map<MarcaViewModel>(entidade);

        }

        public bool RemoveMarca(int id)
        {
            var entidade = Repositorio.Get(id);
            if (entidade != null)
            {
                Repositorio.Remove(entidade);
                return true;
            }
            return false;
        }
        private void ValidarNome(int id, string nome)
        {
            var marca = Repositorio.Get(x => x.Nome.ToLowerInvariant().Equals(nome.ToLowerInvariant()));
            if ((marca != null && marca.Id != id) || (marca != null && id == 0))
            {
                throw new Exception($"Marca '{nome}' cadastrada");
            }
        }
    }
}
