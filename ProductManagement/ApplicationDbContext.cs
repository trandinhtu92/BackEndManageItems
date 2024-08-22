
using Microsoft.EntityFrameworkCore;
namespace ProductManagement
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
           // Database.EnsureCreated();
        }
        public DbSet<ProductModel> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region thêm khóa cho bảng
            modelBuilder.Entity<ProductModel>().HasKey(e => new { e.IDProduct });
            #endregion
            #region DB
            modelBuilder.Entity<ProductModel>().ToTable("product");
            base.OnModelCreating(modelBuilder);
            #endregion
        }
    }
}
