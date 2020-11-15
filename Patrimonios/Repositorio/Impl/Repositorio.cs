using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Patrimonios.Context;
using Patrimonios.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Repositorio.Impl
{
    public abstract class Repositorio<T> : IRepositorio<T>
    {
        protected PatrimoniosContext Context { get; set; }
        
        public Repositorio (IServiceProvider service)
        {
            Context = new PatrimoniosContext(service.GetService<DbContextOptions<PatrimoniosContext>>());
        }


        public abstract T Get(int Id);

        public abstract T Get(Func<T, bool> expression);

        public abstract List<T> List(Func<T, bool> expression);

        public abstract List<T> ListAll();

        public abstract void Remove(T entity);

        public abstract void Save(T entity);

    }
}
