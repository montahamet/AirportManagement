using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{//heritage avant l implementation de l interface
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public bool Availabe(int n, Flight flight)
        {
            var capacity = flight.MyPlane.Capacity;
            var nbTickets=flight.Tickets.Count;
            return capacity - nbTickets >= n;
        }

        public void DeletePlane()
        {
            foreach (Plane p in GetMany(p=>DateTime.Now.Year-p.ManufactureDate.Year>10))
            {
                Delete(p);
                Commit();
            }
        }

        public IList<Flight> GetFlights(int n)
        {
            return GetAll().OrderByDescending(p=>p.PlaneId).Take(n).SelectMany(p=>p.Flights).OrderBy(f=>f.FlightDate).ToList();
        }

        public IList<Traveller> GetTravellers(Plane plane)
        {
            return GetById(plane.PlaneId).Flights.SelectMany(f=>f.Tickets).Select(t=>t.MyPassenger).OfType<Traveller>().Distinct().ToList();
        }
    }
}
