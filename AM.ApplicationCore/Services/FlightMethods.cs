using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {   
        public List<Flight> Flights { get; set; } = new List<Flight>();

        

        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dates = new List<DateTime>();
            /* for (int i = 0; i < Flights.Count; i++)
             {
                 if (Flights[i].Destination == destination)
                 {
                     dates.Add(Flights[i].FlightDate);
                 }

             }*/
            /*foreach (Flight f in Flights)
            {
                if (f.Destination == destination) {
                dates.Add(f.FlightDate); 
                }
            }*/
            var query = from f in Flights where f.Destination == destination select f.FlightDate;
            return query.ToList();  // on utilise le linq language pour questionner la base de donnees ou les listes // retour de linq i enumerable
            //return dates;
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.Destination == filterValue)
                        { Console.WriteLine(flight); }
                    }
                    break;


                case "FlightDate":
                    foreach (Flight flight in Flights)
                    {
                        if (flight.FlightDate == DateTime.Parse(filterValue))
                        { Console.WriteLine(flight); }
                    }
                    break;
            }

        }

        
        public void ShowFlightDetails(Plane plane)
        {
            var planeFlights = from f in Flights where f.MyPlane==plane select new {f.Destination,f.FlightDate };

            foreach (var item in planeFlights)
            {
                Console.WriteLine(item);

            }
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {

            // Use LINQ to filter flights within the specified date range
            var filteredFlights = from f in Flights where f.FlightDate >= startDate && f.FlightDate <= startDate.AddDays(7) select f;

            // Return the count of filtered flights
            return filteredFlights.Count();
        }
        public double DurationAverage(string destination)
        {
            var query = from f in Flights where f.Destination == destination select f.EstimatedDuration;
            return query.Average();
        }
    }
}
