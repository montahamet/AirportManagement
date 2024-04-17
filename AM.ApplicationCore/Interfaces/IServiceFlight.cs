using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight:IService<Flight>
    {
        IList<Staff> GetStaffs(int id);
        IList<Traveller> GetTravellers(Plane p, DateTime date);
        void DisplayNbreTraveller(DateTime date1, DateTime date2);
    }
}
