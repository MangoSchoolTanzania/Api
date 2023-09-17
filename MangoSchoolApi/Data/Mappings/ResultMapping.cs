using MangoSchoolApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MangoSchoolApi.Data.Mappings
{
    public class ResultMapping : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            // Tabela
            builder.ToTable("Result");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            
            builder.Property(x => x.Arith)
                .IsRequired()
                .HasColumnName("Arith")
                .HasColumnType("int");

            builder.Property(x => x.Kus)
                .IsRequired()
                .HasColumnName("Kus")
                .HasColumnType("int");

            builder.Property(x => x.HE)
                .IsRequired()
                .HasColumnName("HE")
                .HasColumnType("int");

            builder.Property(x => x.SA)
                .IsRequired()
                .HasColumnName("SA")
                .HasColumnType("int");

            builder.Property(x => x.Writ)
                .IsRequired()
                .HasColumnName("Writ")
                .HasColumnType("int");

            builder.Property(x => x.Read)
                .IsRequired()
                .HasColumnName("Read")
                .HasColumnType("int");

            builder.Property(x => x.Total)
                .IsRequired()
                .HasColumnName("Total")
                .HasColumnType("int");

            builder.Property(x => x.Ave)
                .IsRequired()
                .HasColumnName("Ave")
                .HasColumnType("int");

            builder.Property(x => x.Pos)
                .IsRequired()
                .HasColumnName("Pos")
                .HasColumnType("int");

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasColumnName("IsActive")
                .HasColumnType("smallint");

            builder.HasOne(x => x.Class)
                .WithMany(x => x.Results);
        }
    }
}
