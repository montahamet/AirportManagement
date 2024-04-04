using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.infrastructure.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => new { t.PassengerFK, t.FlightFK });
            builder.HasOne(t => t.MyPassenger).WithMany(p=>p.Tickets).HasForeignKey(t=>t.PassengerFK);
            builder.HasOne(t => t.MyFlight).WithMany(p => p.Tickets).HasForeignKey(t => t.FlightFK);

        }
    }
}
