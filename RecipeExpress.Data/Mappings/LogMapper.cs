using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeExpressDomain.Abstract.Log;

namespace RecipeExpress.Data.Mappings
{
    public class LogMapper : IEntityTypeConfiguration<LogEntity>
    {
        public void Configure(EntityTypeBuilder<LogEntity> builder)
        {
            builder.ToTable("LOG");

            builder.Property(l => l.Id).HasColumnName("log_id");
            builder.Property(l => l.CreatedAt).HasColumnName("createdAt");
            builder.Property(l => l.LogMessage).HasColumnName("logMessage");
        }
    }
}
