using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodOverloading
{
    class myclass
    {
        public myclass()
        {
            Console.WriteLine("myclass constructor with null");
        }

        public myclass(int a)
        {
            Console.WriteLine("myclass constructor with int " + a.ToString());
        }

        public myclass(string a)
        {
            Console.WriteLine("myclass constructor with string " + a);
        }

    }


    class overloadingclass : myclass
    {

        public overloadingclass()
        {
            Console.WriteLine("overloading constructor with null");
        }

        public overloadingclass(int a)
        {
            Console.WriteLine("overloading constructor with int " + a.ToString());
        }



        public void hello(int a)
        {
            Console.WriteLine("welcome int " + a.ToString());
        }

        /* overloading is never done based on return type
        public int hello(int a)
        {

        }*/

        public void hello(int a, int b)
        {
            Console.WriteLine("welcome int " + a.ToString() + " and int " + b.ToString());
        }

        public void hello(string a)
        {
            Console.WriteLine("welcome string " + a);
        }


        public void hello(string a, int b)
        {
            Console.WriteLine("welcome string " + a + " and int" + b.ToString());
        }

        public void hello(int b, string a)
        {
            Console.WriteLine("welcome int " + b.ToString() + " sting " + a);
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            overloadingclass ob = new overloadingclass(1);
            overloadingclass ob2 = new overloadingclass();
            myclass obj = new myclass("Hello World");
            Console.WriteLine();
            Console.WriteLine();
            ob.hello(1);
            ob.hello(1, 2);
            ob.hello("soumyadeep");
            ob.hello("soumyadeep", 1);
            ob.hello(1, "soumyadeep");

            Console.ReadKey();
        }
    }
}
