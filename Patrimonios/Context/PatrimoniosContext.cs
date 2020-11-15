using Microsoft.EntityFrameworkCore;
using Patrimonios.Context.Map;
using Patrimonios.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Context
{
    public class PatrimoniosContext : DbContext
    {
        public DbSet <Usuario> Usuario{ get; set; }
        public DbSet <Marca> Marca { get; set; }
        public DbSet <Patrimonio> Patrimonio { get; set; }
        public PatrimoniosContext(DbContextOptions < PatrimoniosContext > options) : base (options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsarioMap());
            builder.ApplyConfiguration(new MarcaMap());
            builder.ApplyConfiguration(new PatrimonioMap());
        }
    }
}
