using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPMVC_EF_Music
{
    public class Track_Person_Role
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int TrackId { get; set; }
        public Track Track{ get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
