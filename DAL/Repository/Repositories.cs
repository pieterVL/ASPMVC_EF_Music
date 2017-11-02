using DAL.DAL;
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
    { public TrackRepository() : base(Context.temp = new MusicContext(), Context.temp.Tracks){}}
}
