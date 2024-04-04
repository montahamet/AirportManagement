using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //controle de saisie et nom des attributs dans la base de donnes 
        //public int Id { get; set; }
        [Display(Name ="Date of Birth")]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress{ get; set; }
        public FullName FullName { get; set; }
        [RegularExpression("^[0-9]{8}$")]
        public string TelNumber { get; set; }
        public virtual ICollection<Ticket> Tickets{ get; set; }
        public override string ToString()
        {
            return "Firstname= "+FullName.FirstName+" LastName= "+FullName.LastName;
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
                return this.FullName.FirstName == firstname && this.FullName.LastName == lastname ;
            }
            else
                return this.FullName.FirstName == firstname && this.FullName.LastName == lastname && this.EmailAddress == email;
        }
        public virtual void PassengerType () {
            Console.WriteLine("I am a Passenger");
        }

    }
}
