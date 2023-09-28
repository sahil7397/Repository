using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Data
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users {  get; set; }
    }
}
