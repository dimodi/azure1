using Microsoft.EntityFrameworkCore;

namespace TelerikBlazorEF.Data
{
    public class EfDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne<Category>()
                    .WithMany()
                    .HasForeignKey(p => p.CategoryId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            base.OnModelCreating(modelBuilder);
        }

        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
