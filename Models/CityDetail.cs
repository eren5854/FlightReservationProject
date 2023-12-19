using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CityDetail
    {
        [Key]
        public int CityId { get; set; }

        [StringLength(50)]
        public string CityName { get; set; }

        public int FlightDeatailId { get; set; }
        public virtual FlightDetail FlightDetail { get; set; }

    }
}
