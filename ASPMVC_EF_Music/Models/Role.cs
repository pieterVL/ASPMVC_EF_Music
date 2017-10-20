using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPMVC_EF_Music
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string role { get; set; }

    }
}