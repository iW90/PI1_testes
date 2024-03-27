using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PortsCalculator.Core.Entities;

namespace PortsCalculator.Infra.Database
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("Devices");

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Name)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnType("VARCHAR(500)");

            builder.Property(p => p.AnalogicalInput)
                .HasColumnName("AnalogicalInput")
                .IsRequired()
                .HasColumnType("INT");

            builder.Property(p => p.AnalogicalOutput)
                .HasColumnName("AnalogicalOutput") 
                .IsRequired()
                .HasColumnType("INT");

            builder.Property(p => p.DigitalInput)
                .HasColumnName("DigitalInput")
                .IsRequired()
                .HasColumnType("INT");

            builder.Property(p => p.DigitalOutput)
                .HasColumnName("DigitalOutput")
                .IsRequired()
                .HasColumnType("INT");
        }
    }
}
