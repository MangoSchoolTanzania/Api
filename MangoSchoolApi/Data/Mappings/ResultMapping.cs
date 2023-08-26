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
            builder.ToTable("Studant");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.result)
                .IsRequired()
                .HasColumnName("Result")
                .HasColumnType("FLOAT");

            // Configure the relationships
            builder.HasOne(r => r.Student)
                .WithMany(s => s.Results)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Class)
                .WithMany(c => c.Results)
                .HasForeignKey(r => r.ClassId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
