using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Track_Album   
    {        
        public int Id { get; set; }
        //[Required]
        [Range(1, int.MaxValue)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] //when things need to get messy
        public int TrackSequence { get; set; }
        [Required]
        public int TrackId { get; set; }
        public Track Track { get; set; }
        [Required]
        public int AlbumId { get; set; }
        public Album Album { get; set; }



    }
}
