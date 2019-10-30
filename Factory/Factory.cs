using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{

    public interface IAnimal
    {
        void Speak();
        void Action();
    }

    public class Dog : IAnimal
    {
        private static Dog _instance;

        private Dog()
        {

        }

        public static Dog GetDog
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Dog();
                }
                return _instance;
            }
        }

        public void Speak()
        {
            Console.WriteLine("Dog says: Bow-Wow.");
        }
        public void Action()
        {
            Console.WriteLine("Dogs prefer barking...");
        }
    }



    public sealed class Tiger : IAnimal
    {

        private static Tiger _instance;

        private Tiger()
        {

        }

        public static Tiger GetTiger
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Tiger();
                }
                return _instance;
            }
        }

        public void Speak()
        {
            Console.WriteLine("Tiger says: Halum.");
        }
        public void Action()
        {
            Console.WriteLine("Tigers prefer hunting...");
        }
    }




    public sealed class Cat : IAnimal
    {

        private static Cat _instance;


        private Cat()
        {

        }

        public static Cat GetCat
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Cat();
                }
                return _instance;
            }
        }


        public void Speak()
        {
            Console.WriteLine("Cat says: Meow.");
        }
        public void Action()
        {
            Console.WriteLine("Tigers prefer Couch...");
        }
    }





    public abstract class ISimpleFactory
    {
        public abstract IAnimal CreateAnimal(string value);
    }



    public sealed class SimpleFactory : ISimpleFactory
    {

        private static SimpleFactory _instance;

        private SimpleFactory()
        {

        }

        public static SimpleFactory GetFactory
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SimpleFactory();
                }
                return _instance;
            }
        }


        public override IAnimal CreateAnimal(string b1)
        {
            IAnimal intendedAnimal = null;
            Console.WriteLine("Enter your choice(0 for Dog, 1 for Tiger, 2 for Cat)");
            
            int input;

            if (int.TryParse(b1, out input))
            {
                Console.WriteLine("You have entered {0}", input);
                switch (input)
                {
                    case 0:
                        intendedAnimal = Dog.GetDog;
                        break;
                    case 1:
                        intendedAnimal = Tiger.GetTiger;
                        break;
                    case 2:
                        intendedAnimal = Cat.GetCat;
                        break;
                    default:
                        Console.WriteLine("You must enter either 0, 1 or 2");
                        //We'll throw a runtime exception for any other choices.

                        throw new ApplicationException(String.Format
                (" Unknown Animal cannot be instantiated"));
                }
            }
            return intendedAnimal;
        }
    }



    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Simple Factory Pattern Demo***\n");
            IAnimal preferredType = null;

            ISimpleFactory simpleFactory = SimpleFactory.GetFactory;

            #region The code region that will vary based on users  preference

            do
            {
                preferredType = simpleFactory.CreateAnimal("2");
       

            } while (true);
            
            #endregion
           
            #region The codes that do not change frequently
            preferredType.Speak();
            preferredType.Action();
            #endregion
            Console.ReadKey();
        }
    }





}





        
