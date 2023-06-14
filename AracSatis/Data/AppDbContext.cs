using AracSatis.Models.Configuration;
using AracSatis.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AracSatis.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<CarExtra> CarExtras { get; set; }
        public DbSet<ExtraType> ExtraTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<Image> Images { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new CarExtraConfiguration());
            builder.ApplyConfiguration(new ExtraConfiguration());
            builder.ApplyConfiguration(new ExtraTypeConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new FuelTypeConfiguration());
            builder.ApplyConfiguration(new TransmissionTypeConfiguration());
            builder.ApplyConfiguration(new ImageConfiguration());
        }
        
    }
}
