using AracSatis.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AracSatis.Models.Configuration
{
    public class ExtraTypeConfiguration : BaseConfiguration<ExtraType>
    {
        public override void Configure(EntityTypeBuilder<ExtraType> builder)
        {
            base.Configure(builder);
        }
    }
}
