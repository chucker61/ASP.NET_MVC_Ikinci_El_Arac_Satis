using AracSatis.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AracSatis.Models.Configuration
{
    public class CarConfiguration : BaseConfiguration<Car>
    {
        public override void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasOne(x => x.Category).WithMany(x => x.Cars).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.FuelType).WithMany(x => x.Cars).HasForeignKey(x => x.FuelTypeId);
            builder.HasOne(x => x.TransmissionType).WithMany(x => x.Cars).HasForeignKey(x => x.TransmissionTypeId);
            builder.HasOne(x => x.Post).WithOne(x => x.Car).HasForeignKey<Post>(x => x.CarId);
        }
    }
}
