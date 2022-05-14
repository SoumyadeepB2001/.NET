using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    public delegate void AddDelegate(int a, int b);
    public delegate string GreetingsDelegate(string name);


    class Program
    {
        //Non-static method
        public void Add(int x, int y)
        {
            Console.WriteLine("The Sum of {0} and {1}, is {2} ", x, y, (x + y));
        }

        //Static Method
        public static string Greetings(string name)
        {
            return "Hello " + name;
        }


        static void Main(string[] args)
        {
            Program obj = new Program();
            //calling non-static method through object
            obj.Add(100, 100);
            AddDelegate ad = new AddDelegate(obj.Add);
            ad(2, 3);

            //Calling static method with class name
            string GreetingsMessage = Program.Greetings("Soumyadeep");
            Console.WriteLine(GreetingsMessage);

            GreetingsDelegate gd = new GreetingsDelegate(Program.Greetings);
            Console.WriteLine(gd("Somnath"));

            Console.ReadKey();

        }
    }
}
