using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CRUDTrack_GenreRepository<TTrack_Genre,TTrack,TGenre> : CRUDRepository<TTrack_Genre>
        where TTrack_Genre : class
        where TTrack: class
        where TGenre: class
    {
        public DbSet<TTrack_Genre> DBTrack_Genre;
        public DbSet<TTrack> DBTrack;
        public DbSet<TGenre> DBGenre;
        public CRUDTrack_GenreRepository(DbContext Context, DbSet<TTrack_Genre> DBTrack_Genre, DbSet<TTrack> DBTrack, DbSet<TGenre> DBGenre) : base(Context, DBTrack_Genre)
        {
            this.DBTrack_Genre = DBTrack_Genre;
            this.DBTrack = DBTrack;
            this.DBGenre = DBGenre;
        }

        public IQueryable<TTrack_Genre> Include (System.Linq.Expressions.Expression<Func<TTrack_Genre, TTrack>> path)
        {
            return Dbset.Include(path);            
        }
        public IQueryable<TTrack_Genre> Include(System.Linq.Expressions.Expression<Func<TTrack_Genre, TGenre>> path)
        {
            return Dbset.Include(path);
        }
    }
    public class CRUDTrack_Person_RoleRepository<TTrack_Person_Role, TTrack, TPerson, TRole> : CRUDRepository<TTrack_Person_Role>
       where TTrack_Person_Role : class
       where TTrack : class
       where TPerson : class
       where TRole : class
    {
        public DbSet<TTrack_Person_Role> DBTrack_Genre;
        public DbSet<TTrack> DBTrack;
        public DbSet<TPerson> DBPerson;
        public DbSet<TRole> DBRole;
        public CRUDTrack_Person_RoleRepository(DbContext Context, DbSet<TTrack_Person_Role> DBTrack_Genre, DbSet<TTrack> DBTrack, DbSet<TPerson> DBPerson, DbSet<TRole> DBRole) : base(Context, DBTrack_Genre)
        {
            this.DBTrack_Genre = DBTrack_Genre;
            this.DBTrack = DBTrack;
            this.DBPerson = DBPerson;
            this.DBRole = DBRole;
        }

        public IQueryable<TTrack_Person_Role> Include(System.Linq.Expressions.Expression<Func<TTrack_Person_Role, TTrack>> path)
        {
            return Dbset.Include(path);
        }
        public IQueryable<TTrack_Person_Role> Include(System.Linq.Expressions.Expression<Func<TTrack_Person_Role, TPerson>> path)
        {
            return Dbset.Include(path);
        }
        public IQueryable<TTrack_Person_Role> Include(System.Linq.Expressions.Expression<Func<TTrack_Person_Role, TRole>> path)
        {
            return Dbset.Include(path);
        }
    }
}
