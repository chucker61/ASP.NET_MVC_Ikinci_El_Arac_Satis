using AracSatis.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AracSatis.Models.Configuration
{
    public class CarExtraConfiguration : BaseConfiguration<CarExtra>
    {
        public override void Configure(EntityTypeBuilder<CarExtra> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.Id);
            builder.HasKey(x => new
            {
                x.CarId,
                x.ExtraId
            });
        }
    }
    
}
