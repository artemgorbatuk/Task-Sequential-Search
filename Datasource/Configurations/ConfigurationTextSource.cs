using Datasource.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datasource.Configurations
{
    public class ConfigurationTextSource : IEntityTypeConfiguration<TextSource>
    {
        public void Configure(EntityTypeBuilder<TextSource> builder)
        {
            builder.ToTable("TestTable", "dbo");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.TextData)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}