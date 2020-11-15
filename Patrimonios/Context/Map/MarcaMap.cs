using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patrimonios.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Context.Map
{
    public class MarcaMap : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.HasKey(entidade => entidade.Id);
            builder.Property(entidade => entidade.Nome).IsRequired();
            builder.HasMany(entidade => entidade.Patrimonios).WithOne(entidade => entidade.Marca);
        }
    }
}
