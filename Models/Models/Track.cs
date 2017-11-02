using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Track
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public string Extention { get; set; }
        [Range(1, int.MaxValue)]
        public int length { get; set; }
    }
}