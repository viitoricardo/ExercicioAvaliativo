using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patrimonios.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Context.Map
{
    public class PatrimonioMap : IEntityTypeConfiguration<Patrimonio>
    {
        public void Configure(EntityTypeBuilder<Patrimonio> builder)
        {
            builder.HasKey(entidade => entidade.NumeroTombo);
            builder.Property(entidade => entidade.Nome).IsRequired();
            builder.Property(entidade => entidade.Descricao).IsRequired(false);
            builder.HasOne(entidade => entidade.Marca).WithMany(marca => marca.Patrimonios).IsRequired();


        }
    }
}
