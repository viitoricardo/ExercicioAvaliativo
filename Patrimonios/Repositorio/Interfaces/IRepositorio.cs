using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Repositorio.Interfaces
{
    public interface IRepositorio <T>
    {
        void Remove(T entity);
        void Save(T entity);
        T Get(int Id);
        T Get(Func<T, bool> expression);
        List<T> ListAll();
        List<T> List(Func<T, bool> expression);
    }
}
