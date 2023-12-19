using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SeatDetail
    {
        [Key]
        public int SeatId { get; set; }
        public string SeatType { get; set; }

        [StringLength(5)]
        public string SeatName { get; set; }
        public bool IsActive { get; set; }

        public int PlaneDetailId { get; set; }
        public virtual PlaneDetail PlaneDetail { get; set; }
    }
}
