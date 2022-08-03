using System;

namespace inheritanceAndPolymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare objects
            Dogs dogs = new Dogs();
            //Dogs was Corgi
            Dogs corgi = new Corgi();
            Husky husky = new Husky();

            //Show parent class variable
            Console.WriteLine($"All dogs's cuteness level is {Dogs.cuteLevel++}");
            Console.WriteLine($"The Corgi's cuteness level is {Corgi.cuteLevel++}");
            Console.WriteLine($"The Husky's cuteness level is {Husky.cuteLevel++}");
            
            //Show derived classes have their own variables, shows polymorphism
            Console.WriteLine(" ");
            Console.WriteLine(dogs.favoriteActivity());
            Console.WriteLine(corgi.favoriteActivity());
            Console.WriteLine(husky.favoriteActivity());

            //Show derived classes have their own variables, shows polymorphism
            Console.WriteLine($"\nAll dogs are from size {dogs.Size}");
            Console.WriteLine($"A Corgi is size {corgi.Size}");
            Console.WriteLine($"A Husky is size {husky.Size}");

            //Count up the parent class variable
            Dogs.cuteLevel++;
            Corgi.cuteLevel++;
            Husky.cuteLevel++;

            //All derived classes have the same cuteLevel as the parent's class because we never did polymorphism for that variable
            Console.WriteLine($"\nWhen asleep, all dogs' cute level is {corgi.getCuteLevel()}");
            Console.WriteLine($"When asleep, a Corgi's cute level is {corgi.getCuteLevel()}");
            Console.WriteLine($"When asleep, a Husky's cute level is {husky.getCuteLevel()}");

            // Below code is example of up cast and down cast
            Corgi corgi1 = (Corgi) corgi; 
            Console.WriteLine(corgi1.example());

        }
    }
}
