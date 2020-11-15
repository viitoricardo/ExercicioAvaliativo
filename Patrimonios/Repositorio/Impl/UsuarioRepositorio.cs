using Patrimonios.Entidade;
using Patrimonios.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Repositorio.Impl
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(IServiceProvider service) : base(service)
        {

        }
        public override Usuario Get(int Id)
        {
            return Get(x => x.Id == Id);
        }

        public override Usuario Get(Func<Usuario, bool> expression)
        {
            return Context.Usuario.ToList().FirstOrDefault(expression);
        }

        public override List<Usuario> List(Func<Usuario, bool> expression)
        {
            return Context.Usuario.Where(expression).ToList();
        }

        public override List<Usuario> ListAll()
        {
            return Context.Usuario.ToList();
        }

        public override void Remove(Usuario entity)
        {
            var Usuario = Get(entity.Id);
            Context.Usuario.Remove(Usuario);
            Context.SaveChanges();
        }

        public override void Save(Usuario entity)
        {
            if (entity.Id > 0)
            {
                var Usuario = Get(entity.Id);
                Context.Entry(Usuario).CurrentValues.SetValues(entity);
            }
            else
            {
                Context.Usuario.Add(entity);
            }
            Context.SaveChanges();
        }
    }
}
