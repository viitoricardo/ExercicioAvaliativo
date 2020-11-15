using Patrimonios.Entidade;
using Patrimonios.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Repositorio.Impl
{
    public class PatrimonioRepositorio : Repositorio<Patrimonio>, IPatrimonioRepositorio
    {
        public PatrimonioRepositorio(IServiceProvider service) : base(service)
        {

        }
        public override Patrimonio Get(int Id)
        {
            return Get(x => x.NumeroTombo == Id);
        }

        public override Patrimonio Get(Func<Patrimonio, bool> expression)
        {
            return Context.Patrimonio.ToList().FirstOrDefault(expression);
        }

        public override List<Patrimonio> List(Func<Patrimonio, bool> expression)
        {
            return Context.Patrimonio.Where(expression).ToList();
        }

        public override List<Patrimonio> ListAll()
        {
            return Context.Patrimonio.ToList();
        }

        public override void Remove(Patrimonio entity)
        {
            var patrimonio = Get(entity.NumeroTombo);
            Context.Patrimonio.Remove(patrimonio);
            Context.SaveChanges();
        }

        public override void Save(Patrimonio entity)
        {
            var marca = Context.Marca.FirstOrDefault(x => x.Id == entity.Marca.Id);
            if (marca != null)
            {
                entity.Marca = marca;
            }
            if (entity.NumeroTombo > 0)
            {
                var patrimonio = Get(entity.NumeroTombo);
                
                Context.Entry(patrimonio).CurrentValues.SetValues(entity);
            }
            else
            {
                Context.Patrimonio.Add(entity);
            }
            Context.SaveChanges();
        }
    }
}
