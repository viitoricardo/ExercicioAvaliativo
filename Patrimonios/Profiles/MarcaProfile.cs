using AutoMapper;
using Patrimonios.Entidade;
using Patrimonios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Profiles
{
    public class MarcaProfile : Profile
    {
        public MarcaProfile ()
        {
            CreateMap<Marca, MarcaViewModel>().ReverseMap();
        }
    }
}
