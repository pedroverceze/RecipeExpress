using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeExpressDomain.Recipes.Entities;

namespace RecipeExpress.Data.Mappings
{
    public class RecipeMapper : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("RECIPE");

            builder.HasKey(r => r.RecipeId);

            builder.Property(b => b.RecipeId).HasColumnName("recipe_id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("recipe_name").IsRequired();
            builder.Property(b => b.Dificult).HasColumnName("recipe_difficult").IsRequired();
            builder.Property(b => b.PrepareMode).HasColumnName("recipe_prepare_mode").IsRequired();
            builder.Property(b => b.CreatedAt).HasColumnName("createdAt").IsRequired();
            builder.Property(b => b.CreatedBy).HasColumnName("createdBy");
            builder.Ignore(b => b.Clients);
        }
    }
}
