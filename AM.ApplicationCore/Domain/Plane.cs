using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType{Boing,Airbus};
    public class Plane
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlanedId { get; set; }
        public PlaneType planetype { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return "La Capacite = "+ Capacity;
        }
        //public Plane(PlaneType pt, int capacity, DateTime date)
        //{
        //    this.Capacity = capacity;
        //    this.planetype = pt;
        //    this.ManufactureDate = date;
        //}

        //public Plane()
        //{
        //}
    }
}
