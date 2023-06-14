using AracSatis.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AracSatis.Models.Configuration
{
    public class FuelTypeConfiguration : BaseConfiguration<FuelType>
    {
        public override void Configure(EntityTypeBuilder<FuelType> builder)
        {
            base.Configure(builder);
        }
    }
}
