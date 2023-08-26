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
            builder.ToTable("Class");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("UserName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.Year)
                .IsRequired()
                .HasColumnName("Year")
                .HasColumnType("int");

            builder.Property(x => x.Semester)
                .IsRequired()
                .HasColumnName("Semester")
                .HasColumnType("int");

            builder.HasMany(c => c.Students)   // Class has many students
                  .WithMany(s => s.Classes)   // Student is in many classes
                  .UsingEntity(j => j.ToTable("ClassStudent")); // Intermediate table

            // Configure the relationships
            builder.HasMany(c => c.Results)
                .WithOne(r => r.Class)
                .HasForeignKey(r => r.ClassId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
