using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PlaneDetail
    {
        [Key]
        public int PlaneId { get; set; }

        [StringLength(100)]
        public string PlaneName { get; set; }

        [StringLength(250)]
        public string PlaneDescription { get; set;}

        public ICollection<SeatDetail> SeatDetails { get; set; }

        public int FlightDetailId { get; set; }
        public virtual FlightDetail FlightDetail { get; set; }

    }
}
