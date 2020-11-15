using Patrimonios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Services.Interface
{
    public interface IMarcaService
    {
        List<MarcaViewModel> ListarMarcas();
        MarcaViewModel ObterMarca(int id);
        MarcaViewModel EditarMarca(MarcaViewModel marca);
        MarcaViewModel InserirMarca(MarcaViewModel marca);
        bool RemoveMarca(int id);
    }
}
