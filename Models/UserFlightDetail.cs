using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserFlightDetail
    {
        [Key]
        public int UserFlightDetailId { get; set; }
        public ICollection<UserDetail> UserDetails { get; set; }
        public ICollection<FlightDetail> FlightDetails { get; set; }

    }
}
