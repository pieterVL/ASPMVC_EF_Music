using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPMVC_EF_Music
{
    public class Track_Genre   
    {        
        public int Id { get; set; }
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public int GenreID { get; set; }
        public Genre genre { get; set; }



    }
}
