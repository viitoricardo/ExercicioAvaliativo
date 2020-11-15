using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Patrimonios.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patrimonios.Context.Map
{
    public class UsarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(entidade => entidade.Id);
            builder.Property(entidade => entidade.Nome).IsRequired();
            builder.Property(entidade => entidade.Senha).IsRequired();
            builder.Property(entidade => entidade.Email).IsRequired();
            builder.Property(entidade => entidade.Role).IsRequired(false);
        }
    }
}
