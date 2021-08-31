using biblioteca_AspNetWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_AspNetWebApi.Data
{
    public class BibliotecaContext : DbContext 
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Clerk> Clerks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Punishment> Punishments { get; set; }
    }
}