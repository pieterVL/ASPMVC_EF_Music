using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string role { get; set; }
    }
}