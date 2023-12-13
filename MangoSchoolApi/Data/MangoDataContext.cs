using MangoSchoolApi.Data.Mappings;
using MangoSchoolApi.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace MangoSchoolApi.Data
{
    public class MangoDataContext : DbContext
    {
        private readonly string _Prod;

        public MangoDataContext()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                                                .AddJsonFile("appsettings.json")
                                                .AddEnvironmentVariables()
                                                .Build();

            var value = config.GetRequiredSection("Config").Get<Config>();

            _Prod = value.Prod;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Contact> Contacts { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_Prod);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new ResultMapping());
            modelBuilder.ApplyConfiguration(new ClassMapping());
            modelBuilder.ApplyConfiguration(new ContactMapping());


        }
    }
}
    