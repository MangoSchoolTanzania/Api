using MangoSchoolApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MangoSchoolApi.Data.Mappings
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Tabela
            builder.ToTable("Student");

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

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.Age)
                .IsRequired()
                .HasColumnName("Age")
                .HasColumnType("INT");

            builder.HasMany(s => s.Classes)    // Student has many classes
                   .WithMany(c => c.Students)  // Class has many students
                   .UsingEntity(j => j.ToTable("ClassStudent")); // Intermediate table

            // Configure the relationships
            builder.HasMany(s => s.Results)
                .WithOne(r => r.Student)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
