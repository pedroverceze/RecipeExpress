using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeExpressDomain.Clients.Entities;
using RecipeExpressDomain.Recipes.Entities;

namespace RecipeExpress.Data.Mappings
{
    public class ClientMapper : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("CLIENT");

            builder.HasKey(s => s.ClientId);

            builder.Property(c => c.ClientId).HasColumnName("client_id").IsRequired();
            builder.Property(c => c.Name).HasColumnName("client_name").IsRequired();
            builder.Property(c => c.Age).HasColumnName("client_age").IsRequired();
            builder.Property(c => c.Genre).HasColumnName("client_genre").IsRequired();
            builder.Property(c => c.CreatedAt).HasColumnName("createdAt").IsRequired();
            //builder.HasOne(c => c.Recipes).WithMany().HasForeignKey<Client, Recipe>
        }
    }
}
