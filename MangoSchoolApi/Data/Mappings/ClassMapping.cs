using MangoSchoolApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MangoSchoolApi.Data.Mappings
{
    public class ClassMapping : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            // Tabela
            builder.ToTable("Result");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("UserName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasColumnName("IsActive")
                .HasColumnType("smallint");

            builder.Property(x => x.Month)
                .IsRequired()
                .HasColumnName("Month")
                .HasColumnType("int");


            builder.Property(x => x.Year)
                            .IsRequired()
                            .HasColumnName("Year")
                            .HasColumnType("int");

            builder.HasMany(x => x.Results)
                .WithOne(x => x.Class);
               

        }
    }
}
