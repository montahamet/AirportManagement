using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime Birthdate { get; set; }
        public string PassportNumber { get; set; }
        public string EmailAddress{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelNumber { get; set; }
        public ICollection<Flight> Flights{ get; set; }
        public override string ToString()
        {
            return "Firstname= "+FirstName+" LastName= "+LastName;
        }
        /* public bool CheckProfile(String firstname ,  String lastname)
         {
             return this.FirstName==firstname && this.LastName==lastname;
         }
         public bool CheckProfile(String firstname, String lastname,string email)
         {
             return this.FirstName == firstname && this.LastName == lastname && this.EmailAddress == email;
         }*/
        public bool CheckProfile(String firstname, String lastname, string? email = null)
        {
            if (email == null)
            {
                return this.FirstName == firstname && this.LastName == lastname ;
            }
            else
                return this.FirstName == firstname && this.LastName == lastname && this.EmailAddress == email;
        }
        public virtual void PassengerType () {
            Console.WriteLine("I am a Passenger");
        }
    }
}
