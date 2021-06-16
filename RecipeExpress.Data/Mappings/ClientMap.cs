using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeExpressDomain.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpress.Data.Mappings
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.ClientId);

            builder.Property(c => c.ClientId)
                .IsRequired()
                .HasColumnName("client_id");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("client_name");

            builder.Property(c => c.Age)
                .IsRequired()
                .HasColumnName("client_age");

            builder.Property(c => c.Genre)
                .IsRequired()
                .HasColumnName("client_genre");

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnName("createdAt");

            builder.ToTable("CLIENT");
        }
    }
}
