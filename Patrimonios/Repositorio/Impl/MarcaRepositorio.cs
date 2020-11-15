using Patrimonios.Entidade;
using Patrimonios.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Repositorio.Impl
{
    public class MarcaRepositorio : Repositorio<Marca>, IMarcaRepositorio
    {
        public MarcaRepositorio(IServiceProvider service) : base(service)
        {

        }
        public override Marca Get(int Id)
        {
            return Get(x => x.Id == Id);
        }

        public override Marca Get(Func<Marca, bool> expression)
        {
            return Context.Marca.ToList().FirstOrDefault(expression);
        }

        public override List<Marca> List(Func<Marca, bool> expression)
        {
            return Context.Marca.Where(expression).ToList();
        }

        public override List<Marca> ListAll()
        {
            return Context.Marca.ToList();
        }

        public override void Remove(Marca entity)
        {
            var Marca = Get(entity.Id);
            Context.Marca.Remove(Marca);
            Context.SaveChanges();
        }

        public override void Save(Marca entity)
        {
            if (entity.Id > 0)
            {
                var Marca = Get(entity.Id);
                Context.Entry(Marca).CurrentValues.SetValues(entity);
            }
            else
            {
                Context.Marca.Add(entity);
            }
            Context.SaveChanges();
        }
    }
}
