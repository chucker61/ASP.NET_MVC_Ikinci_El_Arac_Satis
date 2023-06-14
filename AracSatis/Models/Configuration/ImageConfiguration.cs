using AracSatis.Models.Entity;

namespace AracSatis.Models.Configuration
{
    public class ImageConfiguration : BaseConfiguration<Image>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Image> builder)
        {
            base.Configure(builder);
        }
    }
}
