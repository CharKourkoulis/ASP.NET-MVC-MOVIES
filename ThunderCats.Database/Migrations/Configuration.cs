namespace ThunderCats.Database.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ThunderCats.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<ThunderCats.Database.TsirkoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ThunderCats.Database.TsirkoContext context)
        {

            //--------------------Categories-----------------------------------//

            Category c1 = new Category() { Name = "Action" };
            Category c2 = new Category() { Name = "Drama" };
            Category c3 = new Category() { Name = "Comedy" };
            Category c4 = new Category() { Name = "Horror" };
            context.Categories.AddOrUpdate(x => x.Name, c1, c2, c3);
            context.SaveChanges();


            //-------------------Actors-----------------------------------------//
            Actor a1 = new Actor() { Id = 1, Name = "Stallone", Age = 72 };
            Actor a2 = new Actor() { Id = 2, Name = "Schwartz", Age = 66 };
            Actor a3 = new Actor() { Id = 3, Name = "Nicholson", Age = 76 };
            context.Actors.AddOrUpdate(x => x.Name, a1, a2, a3);
            context.SaveChanges();

            //-----------------------Directors-----------------------------------//
                
            Director d1 = new Director() { Id = 1, Name = "Copolla", Age = 72 };
            Director d2 = new Director() { Id = 2, Name = "Hitchcock", Age = 72 };
            Director d3 = new Director() { Id = 3, Name = "Tarantino", Age = 72 };
            context.Directors.AddOrUpdate(x => x.Name, d1, d2, d3);
            context.SaveChanges();


            //------------------Movies------------------------------------------//

            Movie m1 = new Movie() { Id = 1, Title = "Terminator", Year = 2019, Watched = false, Category = c4, Director = d3 };
            m1.Actors.Add(a1);
            m1.Actors.Add(a2);
            m1.Actors.Add(a3);

            context.Movies.AddOrUpdate(m => m.Title, m1);
            context.SaveChanges();

        }
    }
}
