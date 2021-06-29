using MathGameAPI.DTO;
using Microsoft.EntityFrameworkCore;

namespace MathGameAPI
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DataContext(){}
        public DbSet<User> Users {get; set;}
    }
}