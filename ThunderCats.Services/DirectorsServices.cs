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
    public class DirectorsServices
    {

        public Director GetDirector(int? id)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                return db.Directors.Find(id);
            }
        }


        public List<Director> GetDirectors()
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                return db.Directors.ToList();
            }
        }

        public List<Director> GetDirectors(string searchDirectors)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                var Directors = from a in db.Directors
                             select a;

                if (!String.IsNullOrEmpty(searchDirectors))
                {
                    Directors = Directors.Where(s => s.Name.Contains(searchDirectors));
                }
                return Directors.ToList();
            }
        }


        public void SaveDirector(Director Director)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                db.Directors.Add(Director);
                db.SaveChanges();

            }
        }


        public void UpdateDirector(Director Director)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                db.Entry(Director).State = EntityState.Modified;
                db.SaveChanges();

            }
        }

        public void DeleteDirector(Director Director)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                db.Entry(Director).State = EntityState.Deleted;
                db.SaveChanges();

            }
        }


    }
}