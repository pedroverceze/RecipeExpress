using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeExpressDomain.Client.Entities;

namespace RecipeExpress.Data.Mappings
{
    public class ClientMapper : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("CLIENT");

            builder.HasKey(s => s.ClientId);

            builder.Property(b => b.ClientId).HasColumnName("client_id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("client_name").IsRequired();
            builder.Property(b => b.Age).HasColumnName("client_age").IsRequired();
            builder.Property(b => b.Genre).HasColumnName("client_genre").IsRequired();
            builder.Property(b => b.CreatedAt).HasColumnName("createdAt").IsRequired();
            builder.Ignore(b => b.Recipes);
        }
    }
}
