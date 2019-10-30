using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPempti
{

    class MainApp

    {

        public static void FactoryMethod(int input)
        {
            var products = new List<ICannes>();

         

        }


        static void Main()

        {

            Console.WriteLine("Ti Thermokrasia exei to Psygeio??");
            Console.WriteLine("Pata 1 gia poly xamili thermokrasia, Pata 2 gia metria thermokrasia, 3 gia ypsili thermokrasia");
            var input = Convert.ToInt32(Console.ReadLine());

           


            Console.ReadKey();

        }


    }


    public interface ICannes
    {
       ICollection<IPot> CreatePot();
    }


    public class CannesA : ICannes
    {
        public  ICollection<IPot> CreatePot()
        {

            var products = new List<IPot>();
            IPot p1 = new Pot();
            IPot p2 = new Pot();
            products.Add(p1);
            products.Add(p2);

            return products;
        }
    }

    public class CannesB : ICannes
    {
        public  ICollection<IPot> CreatePot()
        {
            var products = new List<IPot>();
            IPot p1 = new Pot() { Id=1, Name="Xorto Kaloutsiko" };
            IPot p2 = new Beer() { Id = 2, Name = "Pagmwneni Mpyra" };
            products.Add(p1);
            products.Add(p2);

            return products;
        }
    }

    public class CannesC : ICannes
    {
        public  ICollection<IPot> CreatePot()
        {
            var products = new List<IPot>();
            IPot p1 = new Pot() { Id = 1, Name = "Xorto pio Kalo apo to allo" };
            IPot p2 = new Beer() { Id = 2, Name = "Pio Pagwmeni Mpyra" };
            IPot p3 = new CocaCola() { Id = 1, Name = "Pagwmeni Coca Cola" };
            products.Add(p1);
            products.Add(p2);
            products.Add(p3);

            return products;
        }
    }







    public interface IPot
    {
         int Id { get; set; }
        string Name { get; set; }
        int Price { get; set; }
    }


    public class Pot : IPot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public class Beer : IPot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public class CocaCola : IPot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }


}






