﻿using DAL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    class Context {
        static public MusicContext temp;
    }
    public class AlbumRepository : CRUDRepository<Album>
    { public AlbumRepository() : base(Context.temp = new MusicContext(), Context.temp.Albums){}}

    public class GenreRepository : CRUDRepository<Genre>
    { public GenreRepository() : base(Context.temp = new MusicContext(), Context.temp.Genres){}}

    public class PersonRepository : CRUDRepository<Person>
    { public PersonRepository() : base(Context.temp = new MusicContext(), Context.temp.Persons){}}

    public class RoleRepository : CRUDRepository<Role>
    { public RoleRepository() : base(Context.temp = new MusicContext(), Context.temp.Roles){}}

    public class TrackRepository : CRUDRepository<Track>
    { public TrackRepository() : base(Context.temp = new MusicContext(), Context.temp.Tracks){}
        public void InsertBulk(IEnumerable<Track> Entities)
        {
            Dbset.AddRange(Entities);
        }
    }

    //Juction Classes
    public class Track_AlbumRepository : CRUDRepository<Track_Album>
    { public Track_AlbumRepository() : base(Context.temp = new MusicContext(), Context.temp.Track_Album) { }
        public List<Track_Album> GetAllTracksFromAlbum(int AlbumId) {
            return Dbset.SqlQuery(String.Format(@"
                SELECT Id,TrackSequence,TrackId,AlbumId
                  FROM dbo.Track_Album
                  WHERE {0}= AlbumId
                  Order By TrackSequence",AlbumId)
            ).ToList();
        }
    }

    public class Track_GenreRepository : CRUDTrack_GenreRepository<Track_Genre,Track,Genre>
    { public Track_GenreRepository() : base(Context.temp = new MusicContext(), Context.temp.Track_Genre,Context.temp.Tracks,Context.temp.Genres) { } }
}
