using Patrimonios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Services.Interface
{
   public interface IUsuarioService
    {
        List<UsuarioViewModel> ListarUsuarios();
        UsuarioViewModel ObterUsuario(int id);
        UsuarioViewModel EditarUsuario(UsuarioViewModel usuario);
        UsuarioViewModel InserirUsuario(UsuarioViewModel usuario);
        bool RemoveUsuario(int id);
    }
}
