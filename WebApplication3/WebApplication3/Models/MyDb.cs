using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class MyDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=crud_assig;User Id=sa;Password=aptech;TrustServerCertificate=True");
        }

        public DbSet<Student> students { get; set; }
      

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Product>().HasOne(c => c.category).WithMany(p => p.products).HasForeignKey(p=>p.CatId);
        //}
    }
}
