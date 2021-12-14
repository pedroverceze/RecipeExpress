using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeExpressDomain.Client.Entities;

namespace RecipeExpress.Data.Mappings
{
    public class ClientRecipeMapper : IEntityTypeConfiguration<ClientRecipe>
    {
        public void Configure(EntityTypeBuilder<ClientRecipe> builder)
        {
            builder.ToTable("CLIENT_RECIPE");

            builder.HasKey(cr => new { cr.ClientId, cr.RecipeId });

            builder.HasOne(cr => cr.Client)
                .WithMany(c => c.ClientRecipes)
                .HasForeignKey(clr => clr.ClientId);

            builder.HasOne(cr => cr.Recipe)
                .WithMany(r => r.ClientRecipes)
                .HasForeignKey(rpc => rpc.RecipeId);

            builder.Property(b => b.ClientId).HasColumnName("client_id").IsRequired();
            builder.Property(b => b.RecipeId).HasColumnName("recipe_id").IsRequired();
            builder.Property(b => b.CreatedAt).HasColumnName("createdAt").IsRequired();
        }
    }
}
