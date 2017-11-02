using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMVC_EF_Music
{
    public class Track_AlbumCreateList
    {
            public IEnumerable<Track_Album> ExistingTrack_Albums { get; set; }
            public Track_Album track_album { get; set; }        
    }
}