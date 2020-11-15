using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Models
{
    public class PatrimonioViewModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int NumeroTombo { get; set; }
        public MarcaViewModel Marca { get; set; }
    }
}
