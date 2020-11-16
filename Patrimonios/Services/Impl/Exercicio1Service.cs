using Patrimonios.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Services.Impl
{
    public class Exercicio1Service : IExercio1Service
    {
        public int ObterMaiorNumeroIrmao(int n)
        {
            return maxLista(n);
        }

        private int maxLista(int n)
        {
            if (n < 0 )
            {
                return -1;
            }            

            List<int> lista = new List<int>();
            string numero = n.ToString();

            for (int i = 0; i < numero.Length; i++)
            {
                lista.Add(Convert.ToInt32(numero[i].ToString()));
            }
            lista = lista.OrderByDescending(x => x).ToList();

            n = Convert.ToInt32(string.Join(string.Empty, lista));

            if (n > 100000000)
            {
                n = -1;
            }

            return n;
        }

    }
}
