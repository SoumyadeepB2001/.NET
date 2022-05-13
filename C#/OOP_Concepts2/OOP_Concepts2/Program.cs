using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Concepts2
{
    class a
    {
        public a()
        {
            //implicitely inherits System.object class
            Console.WriteLine("Consturctor of a");
        }
    }

    class b : a
    {
        public b()
        {
            Console.WriteLine("Consturctor of b");
        }
    }


    class c : b
    {
        public c()
        {
            //base(); implicitely called 
            Console.WriteLine("Constructor of c");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Components of child class can not be initialized before initializing the components of parent class
            //So to initialize components of class C, class B needs to be initialized
            //To initialize components of class B, class A needs to be initialized
            c cobj = new c();
            Console.ReadKey();
        }
    }
}
