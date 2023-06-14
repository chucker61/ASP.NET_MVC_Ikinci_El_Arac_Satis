using AracSatis.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AracSatis.Models.Configuration
{
    public class ExtraConfiguration:BaseConfiguration<Extra>
    {
        public override void Configure(EntityTypeBuilder<Extra> builder)
        {
            base.Configure(builder);
        }
    }
}
