using AracSatis.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AracSatis.Models.Configuration
{
    public class PostConfiguration:BaseConfiguration<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);
        }
    }
}
