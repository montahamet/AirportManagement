using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public int FlightFK { get; set; }
        public String PassengerFK { get; set; }
        public double Prix { get; set; }
        public int Siege { get; set; }
        public bool VIP { get; set; }
        public virtual Flight MyFlight { get; set; }
        public virtual Passenger MyPassenger { get; set; }
    }
}
