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
    public class PatrimonioService : IPatrimonioService
    {
        private IPatrimonioRepositorio Repositorio;
        private IMapper Mapper;
        public PatrimonioService(IPatrimonioRepositorio repo, IMapper mapper)
        {
            Repositorio = repo;
            Mapper = mapper;
        }
        public PatrimonioViewModel EditarPatrimonio(int id, PatrimonioEditViewModel patrimonio)
        {
            var entidade = Mapper.Map<Patrimonio>(patrimonio);
            entidade.NumeroTombo = id;
            Repositorio.Save(entidade);
            return Mapper.Map<PatrimonioViewModel>(entidade);
        }

        public PatrimonioViewModel InserirPatrimonio(PatrimonioEditViewModel patrimonio)
        {
            var entidade = Mapper.Map<Patrimonio>(patrimonio);
            Repositorio.Save(entidade);
            return Mapper.Map<PatrimonioViewModel>(entidade);
        }

        public List<PatrimonioViewModel> ListarPatrimonios()
        {
            var entidade = Repositorio.ListAll();
            return Mapper.Map<List<PatrimonioViewModel>>(entidade);
        }

        public PatrimonioViewModel ObterPatrimonio(int numeroTombo)
        {
            var entidade = Repositorio.Get(numeroTombo);
            return Mapper.Map<PatrimonioViewModel>(entidade);
        
        }

        public bool RemovePatrimonio(int numeroTombo)
        {
            var entidade = Repositorio.Get(numeroTombo);
            if (entidade != null)
            {
                Repositorio.Remove(entidade);
                return true;
            }
            return false;
        }
    }
}
