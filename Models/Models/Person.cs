using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [DataType(DataType.Date)]
        public DateTime dayOfBirth { get; set; }
    }
}
