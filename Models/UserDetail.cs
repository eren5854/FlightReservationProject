using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserDetail
    {
        [Key]
        public int UserDetailId { get; set; }

        [Required]
        [StringLength(150)]
        public string UserFirstName { get; set; }

        [Required]
        [StringLength(200)]
        public string UserLastName { get; set; }

        [Required]
        [StringLength(200)]
        public string UserEmail { get; set; }

        [Required]
        [StringLength(128)]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(13)]
        [Phone]
        public string UserPhone { get; set; }

        public int UserFlightDetailId { get; set; }
        public virtual UserFlightDetail UserFlightDetails { get; set; }
    }
}
