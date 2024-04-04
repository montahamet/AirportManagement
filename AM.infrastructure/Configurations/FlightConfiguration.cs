using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Flight> builder)
        {
            builder.HasMany(f=>f.Passangers).WithMany(p=>p.Flights).UsingEntity(t=>t.ToTable("Reservation"));
            builder.HasOne(f => f.MyPlane).WithMany(p => p.Flights).HasForeignKey(f => f.PlaneId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
