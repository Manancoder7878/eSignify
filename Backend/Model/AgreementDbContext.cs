using Microsoft.EntityFrameworkCore;

namespace Backend.Model
{
    public class AgreementDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SignatureDb;Trusted_Connection=True;");
        }
    }
}
