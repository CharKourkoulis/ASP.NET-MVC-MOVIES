using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThunderCats.Entities;

namespace ThunderCats.Database
{
    public  class TsirkoContext : DbContext, IDisposable
    {
        public TsirkoContext() : base("name=Sindesmos")
        {

        }


        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
