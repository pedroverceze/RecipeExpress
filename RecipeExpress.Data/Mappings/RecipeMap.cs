using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeExpressDomain.Recipes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeExpress.Data.Mappings
{
    public class RecipeMap : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(c => c.RecipeId);

            builder.Property(c => c.RecipeId)
                .IsRequired()
                .HasColumnName("recipe_id");

            builder.Property(c => c.ClientId)
                .IsRequired()
                .HasColumnName("client_id");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("recipe_name");

            builder.Property(c => c.Dificult)
                .IsRequired()
                .HasColumnName("recipe_dificult");

            builder.Property(c => c.PrepareMode)
                .IsRequired()
                .HasColumnName("recipe_prepare_mode");

            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnName("createdAt");

            builder.Property(c => c.CreatedBy)
                    .IsRequired()
                    .HasColumnName("createdBy");

            builder.ToTable("RECIPE");
        }
    }
}
