using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMVC_EF_Music
{
    public class GenreCreateList
    {
            public IEnumerable<Genre> ExistingGenres { get; set; }
            public Genre Genre { get; set; }        
    }
}