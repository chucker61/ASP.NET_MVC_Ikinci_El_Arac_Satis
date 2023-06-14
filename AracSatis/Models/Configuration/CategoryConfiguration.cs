using AracSatis.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;

namespace AracSatis.Models.Configuration
{
    public class CategoryConfiguration: BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
        }
    }
}
