using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DisplayNbreTraveller(DateTime date1, DateTime date2)
        {
            var Query = GetMany(f => f.FlightDate >= date1 && f.FlightDate <= date2).SelectMany(f => f.Tickets).GroupBy(t => t.MyFlight.FlightDate).Select(t => new { group = t.Key, count=t.Count() });
            foreach (var item in Query)
            {
                Console.WriteLine("Date vol:"+item.group+"Nbre:"+item.count);
            }
        }

        public IList<Staff> GetStaffs(int id)
        {
            return GetById(id).Tickets.Select(t=>t.MyPassenger).OfType<Staff>().ToList();
        }

        public IList<Traveller> GetTravellers(Plane p, DateTime date)
        {
            return Get(f => f.MyPlane == p && f.FlightDate==date).Tickets.Select(t=>t.MyPassenger).OfType<Traveller>().ToList();
        }
    }
}
