using AutoMapper;
using Patrimonios.Entidade;
using Patrimonios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile ()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}
