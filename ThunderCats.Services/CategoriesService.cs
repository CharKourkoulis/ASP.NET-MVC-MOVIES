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
    public class CategoriesService
    {

        public Category GetCategory(string id)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                return db.Categories.Find(id);
            }
        }



        public List<Category> GetCategories()
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                return db.Categories.ToList();
            }
        }

        public List<Category> GetCategories(string searchCategories)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                var Categories = from a in db.Categories
                             select a;

                if (!String.IsNullOrEmpty(searchCategories))
                {
                    Categories = Categories.Where(s => s.Name.Contains(searchCategories));
                }
                return Categories.ToList();
            }
        }


        public void SaveCategory(Category Categorie)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                db.Categories.Add(Categorie);
                db.SaveChanges();

            }
        }


        public void UpdateCategory(Category Categorie)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                db.Entry(Categorie).State = EntityState.Modified;
                db.SaveChanges();

            }
        }

        public void DeleteCategory(Category Categorie)
        {
            using (var db = new TsirkoContext())
            {
                //Linq // Filtra // Sorting

                db.Entry(Categorie).State = EntityState.Deleted;
                db.SaveChanges();

            }
        }


    }
}

