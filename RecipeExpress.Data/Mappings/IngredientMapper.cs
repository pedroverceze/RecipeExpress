using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeExpressDomain.Ingredients.Entities;

namespace RecipeExpress.Data.Mappings
{
    public class IngredientMapper : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("INGREDIENT");

            builder.HasKey(i => i.IngredientId);

            builder.Property(p => p.IngredientId).HasColumnName("ingredient_id");
            builder.Property(p => p.Name).HasColumnName("ingredient_name");
            builder.Property(p => p.Perishable).HasColumnName("perishable");
            builder.Property(p => p.Type).HasColumnName("type_id");
            builder.Property(p => p.CreatedAt).HasColumnName("createdAt");
        }
    }
}
