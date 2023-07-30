using MangoSchoolApi.Data.Mappings;
using MangoSchoolApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MangoSchoolApi.Data
{
    public class MangoDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Studant> Studants { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Adicionar aqui string de conexão");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new StudantMapping());
            modelBuilder.ApplyConfiguration(new ClassMapping());
            modelBuilder.ApplyConfiguration(new ResultMapping());
        }
    }
}
    