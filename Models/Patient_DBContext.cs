using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Models
{
    public class Patient_DBContext : DbContext
    {
        public Patient_DBContext(DbContextOptions<Patient_DBContext> options)
            : base(options) { }

        public DbSet<Booki> Book { get; set; }
        public DbSet<doct> Doct { get; set; }

        public DbSet<LoginCredential> LoginCredential { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //// Configure one-to-many relationship between doct and Booki
            //modelBuilder.Entity<Booki>()
            //    .HasOne(b => b.doc)
            //    .WithMany() // No specific navigation property needed on the doct side
            //    .HasForeignKey(b => b.did);

            modelBuilder.Entity<doct>()
      .HasMany(d => d.book) // A doctor has many appointments
      .WithOne(b => b.doc)      // An appointment belongs to one doctor
      .HasForeignKey(b => b.did);  // Foreign key in Booki

            base.OnModelCreating(modelBuilder);
        }
    }
}