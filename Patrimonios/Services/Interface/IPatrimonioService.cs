using Patrimonios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Services.Interface
{
    public interface IPatrimonioService
    {
        List<PatrimonioViewModel> ListarPatrimonios();
        PatrimonioViewModel ObterPatrimonio(int numeroTombo);
        PatrimonioViewModel EditarPatrimonio(int id, PatrimonioEditViewModel patrimonio);
        PatrimonioViewModel InserirPatrimonio(PatrimonioEditViewModel patrimonio);
        bool RemovePatrimonio(int numeroTombo);
    }
}
