using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Track_Person_Role
    {
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [Required]
        public int TrackId { get; set; }
        public Track Track{ get; set; }

        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
