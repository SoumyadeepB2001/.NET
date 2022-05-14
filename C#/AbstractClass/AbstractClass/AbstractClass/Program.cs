using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractClass
{
    abstract class myasbstractclass
    {
        public myasbstractclass()
        {
            Console.WriteLine("Constructor of abstract class");
        }


        public int add(int a, int b)
        {
            return a + b;
        }


        abstract public int subs(int a, int b);
    }



    class fullydefinedclass : myasbstractclass
    {
        public fullydefinedclass()
        {
            Console.WriteLine("Constructor of fully defined class");
        }

        public override int subs(int a, int b)
        {
            return a - b;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // myasbstractclass ma = new myasbstractclass(); not possible can not be instantiated

            fullydefinedclass fc = new fullydefinedclass();

            int x, y;

            Console.WriteLine("Enter first number : ");
            x = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number : ");
            y = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("The sum is : " + fc.add(x, y));
            Console.WriteLine("The difference is : " + fc.subs(x, y));

            Console.ReadKey();
        }
    }
}
