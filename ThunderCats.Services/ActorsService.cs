using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThunderCats.Database;
using ThunderCats.Entities;

namespace ThunderCats.Services
{
    public class ActorsService
    {

        public Actor GetActor(int? id)
        {
            using(var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

               return  db.Actors.Find(id);
            }
        }

    

        public List<Actor> GetActors()
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                return db.Actors.ToList();
            }
        }

        public List<Actor> GetActors(string searchActors)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                var actors = from a in db.Actors
                             select a;

                if (!String.IsNullOrEmpty(searchActors))
                {
                    actors = actors.Where(s => s.Name.Contains(searchActors));
                }
                return actors.ToList();
            }
        }


        public void SaveActor(Actor actor)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                db.Actors.Add(actor);
                db.SaveChanges();

            }
        }


        public void UpdateActor(Actor actor)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                db.Entry(actor).State = EntityState.Modified;
                db.SaveChanges();

            }
        }

        public void DeleteActor(Actor actor)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                db.Entry(actor).State = EntityState.Deleted;
                db.SaveChanges();

            }
        }


    }
}
