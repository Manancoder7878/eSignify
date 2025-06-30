using Microsoft.EntityFrameworkCore;

namespace Backend.Model
{
    public class AgreementDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Field> Fields { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SignatureDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>()
                .Property(d => d.DocumentId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Document>()
                .Property(d => d.Status)
                .HasDefaultValue("Unsigned");
            modelBuilder.Entity<Document>()
                .HasOne(d => d.User)
                .WithMany(u => u.Documents)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Recipient>()
                .Property(r => r.RecipientId)
                .HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<Recipient>()
                .HasOne(r => r.Document)
                .WithMany(d => d.Recipients)
                .HasForeignKey(r => r.DocumentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Field>()
                .Property(f => f.FieldId)
                .HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<Field>()
                .HasOne(f => f.Recipient)
                .WithMany(r => r.Fields)
                .HasForeignKey(f => f.RecipientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict); 
            modelBuilder.Entity<Field>()
                .HasOne(f => f.Document)
                .WithMany(d => d.Fields)
                .HasForeignKey(f => f.DocumentId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
