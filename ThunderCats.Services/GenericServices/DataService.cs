//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ThunderCats.Database;
//using ThunderCats.Entities;

//namespace ThunderCats.Services
//{
//    public class DataService <T,M>
//    {

//        public T  GetModel<T>(int? id)
//        {
//            using(var db = new TsirkoContext())
//            {
//                //Linq // Filtra // Sorting

//               return  db.Models.Find(id);
//            }
//        }

    

//        public List<Model> GetModels()
//        {
//            using (var db = new TsirkoContext())
//            {
//                //Linq // Filtra // Sorting

//                return db.Models.ToList();
//            }
//        }

//        public List<Model> GetModels(string searchModels)
//        {
//            using (var db = new TsirkoContext())
//            {
//                //Linq // Filtra // Sorting

//                var Models = from a in db.Models
//                             select a;

//                if (!String.IsNullOrEmpty(searchModels))
//                {
//                    Models = Models.Where(s => s.Name.Contains(searchModels));
//                }
//                return Models.ToList();
//            }
//        }


//        public void SaveModel(Model Model)
//        {
//            using (var db = new TsirkoContext())
//            {
//                //Linq // Filtra // Sorting

//                db.Models.Add(Model);
//                db.SaveChanges();

//            }
//        }


//        public void UpdateModel(Model Model)
//        {
//            using (var db = new TsirkoContext())
//            {
//                //Linq // Filtra // Sorting

//                db.Entry(Model).State = EntityState.Modified;
//                db.SaveChanges();

//            }
//        }

//        public void DeleteModel(Model Model)
//        {
//            using (var db = new TsirkoContext())
//            {
//                //Linq // Filtra // Sorting

//                db.Entry(Model).State = EntityState.Deleted;
//                db.SaveChanges();

//            }
//        }


//    }
//}
