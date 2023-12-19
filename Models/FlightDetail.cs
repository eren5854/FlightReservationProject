using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class FlightDetail
    {
        [Key]
        public int FlightDeatailId { get; set; }
        public ICollection<CityDetail> FromWhere { get; set; }
        //public ICollection<CityDetail> ToWhere { get; set; }
        public DateTime DepartureDate {  get; set; }
        public DateTime Departuretime { get; set; }
        public DateTime DateOfReturn { get; set; }
        public DateTime DateOfreturnTime { get; set; }
        public ICollection<PlaneDetail> Planes { get; set; }
        public bool FlightStatus { get; set; }

        public int UserFlightDetailId { get; set; }
        public virtual UserFlightDetail UserFlightDetails { get; set; }

    }
}
