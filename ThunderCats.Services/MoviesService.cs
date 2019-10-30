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
    public class MoviesService
    {

        public Movie GetMovie(int? id)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                return db.Movies.Find(id);
            }
        }



        public List<Movie> GetMovies()
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                return db.Movies.ToList();
            }
        }

        public List<Movie> GetMovies(string searchMovies)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                var Movies = from a in db.Movies
                             select a;

                if (!String.IsNullOrEmpty(searchMovies))
                {
                    Movies = Movies.Where(s => s.Title.Contains(searchMovies));
                }
                return Movies.ToList();
            }
        }


        public void SaveMovie(Movie Movie)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                db.Movies.Add(Movie);
                db.SaveChanges();

            }
        }


        public void UpdateMovie(Movie Movie)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                db.Entry(Movie).State = EntityState.Modified;
                db.SaveChanges();

            }
        }

        public void DeleteMovie(Movie Movie)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                db.Entry(Movie).State = EntityState.Deleted;
                db.SaveChanges();

            }
        }


    }
}
