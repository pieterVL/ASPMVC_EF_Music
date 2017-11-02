using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL
{
    public class GenreCreateList
    {
            public IEnumerable<Genre> ExistingGenres { get; set; }
            public Genre Genre { get; set; }        
    }
}