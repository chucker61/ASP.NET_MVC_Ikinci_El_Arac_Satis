using AracSatis.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.IO.Pipes;

namespace AracSatis.Models.Configuration
{
    public class TransmissionTypeConfiguration:BaseConfiguration<TransmissionType>
    {
        public override void Configure(EntityTypeBuilder<TransmissionType> builder)
        {
            base.Configure(builder);
        }
    }
}
