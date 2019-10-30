using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
         

        

        }
    }


    public sealed class Singleton
    {
       
        private static Singleton _instance;
      

        private Singleton()
        {
            
        }

        public static Singleton GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }




        public void Print(string email)
        {
            Console.WriteLine("To email sas einai " + email);
        }
    }


}
