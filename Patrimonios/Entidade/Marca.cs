using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Entidade
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList <Patrimonio> Patrimonios { get; set; }
    }
}
