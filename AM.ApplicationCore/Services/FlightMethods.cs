using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {   
        public List<Flight> Flights { get; set; } = new List<Flight>();

        public Action<Plane> FlightDetailsDel; //delegue action pour des methodes void sans retour

        public Func<string,double> DurationAverageDel; //string represente le parametre et double represente le type de retour
        //les deleguees se positionne au niveau du constructeur ou bien au niveau des methodes
        //constructeur ctordouble tab
        public FlightMethods()
        {
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel = DurationAveragedurat
            FlightDetailsDel = Plane =>
            {
                var req = from flight in Flights
                          where flight.MyPlane == Plane
                          select new { flight.FlightDate, flight.Destination };
                foreach (var f in req)
                    Console.WriteLine("Flight date: " + f.FlightDate + "Flight destination :" + f.Destination);
            };
            DurationAverageDel = d =>
            {
                return (from f in Flights
                        where f.Destination == d
                        select f.EstimatedDuration).Average();

            };
        }
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
            //with langage LINQ
            //var query = from f in Flights where f.Destination == destination select f.FlightDate;
            //return query.ToList();  // on utilise le linq language pour questionner la base de donnees ou les listes // retour de linq i enumerable
            //return dates;


            //with lambda expression
            var lambdareq = Flights.Where(f => f.Destination == destination).Select(f=>f.FlightDate);
            return lambdareq.ToList();
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
            //var planeFlights = from f in Flights where f.MyPlane==plane select new {f.Destination,f.FlightDate };

            //foreach (var item in planeFlights)
            //{
            //    Console.WriteLine(item);

            //}
            var reqlambda = Flights.Where(f => f.MyPlane == plane).Select(f => new { f.FlightDate, f.Destination });

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
            //var query = from f in Flights where f.Destination == destination select f.EstimatedDuration;
            //return query.Average();
            var reqlambda = Flights
                          .Where(flight => flight.Destination == destination)
                          .Select(flight => flight.EstimatedDuration);
            return reqlambda.Average();
        }

        public List<Flight> OrderedDurationFlights()
        {
            //return( from f in Flights orderby f.EstimatedDuration descending select f).ToList();
            var reqLambda = Flights.OrderByDescending(f => f.EstimatedDuration);
            return reqLambda.ToList();
        }

        //public IEnumerable<Passenger> SeniorTravellers(Flight flight)
        //{
        //    //return (from p in flight.Passangers.OfType<Traveller>() orderby p.Birthdate select p).Take(3).ToList();
        //    var reqLambda = flight.Passangers.OfType<Traveller>().OrderBy(p => p.Birthdate).Take(3);
        //    return reqLambda;
        //}
        public void DestinationGroupedFlights()
        {

            //var groupedFlights =
            //    from flight in Flights
            //    group flight by flight.Destination;
            var reqLambda = Flights.GroupBy(f => f.Destination);
            
            foreach (var group in reqLambda)
            {
                Console.WriteLine($"Destination: {group.Key}");

                foreach (var flight in group)
                {
                    Console.WriteLine($"Décollage : {flight.FlightDate:yyyy/MM/dd HH:mm:ss}");
                }

                Console.WriteLine();
            }
        }

        
        //public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        //{
        //    var req = from f in Flights
        //              group f by f.Destination;


        //    foreach (var g in req)
        //    {
        //        Console.WriteLine("Destination: " + g.Key);
        //        foreach (var f in g)
        //            Console.WriteLine("Décollage: " + f.FlightDate);
        //    }
        //    return req;
        //}
    }

}
