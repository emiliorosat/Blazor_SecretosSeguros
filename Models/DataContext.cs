using Microsoft.EntityFrameworkCore;

namespace secretsVaul.Models
{
    public class DataContext: DbContext {
        public DbSet<User> Users {get; set;}
        public DbSet<Person> People {get; set;}
        public DbSet<Secret> Secrets {get; set;}
        public DbSet<Coord> Coords {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Data/app.db");
    }
}