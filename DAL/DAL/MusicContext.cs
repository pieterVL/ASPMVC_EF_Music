using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

{
    {
        public MusicContext() : base("ASP_EF_Music") { }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Track_Genre> Track_Genre { get; set; }
        public DbSet<Track_Album> Track_Album { get; set; }
        public DbSet<Track_Person_Role> Track_Person_Role { get; set; }

    }
}
