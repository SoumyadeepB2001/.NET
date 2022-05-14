using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface
{
    public interface addsubs
    {
        int add(int a, int b);
        int subs(int a, int b);
    }

    public interface multdiv : addsubs
    {
        int mult(int a, int b);
        int div(int a, int b);
    }


    class myclass : addsubs, multdiv
    {
        public int add(int a, int b)
        {
            return a + b;
        }

        public int subs(int a, int b)
        {
            return a - b;
        }

        public int mult(int a, int b)
        {
            return a * b;
        }

        public int div(int a, int b)
        {
            return a / b;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            //Like abstract classes, interfaces cannot be used to create objects
            myclass mc = new myclass();
            Console.WriteLine("Sum: " + mc.add(4, 2));
            Console.WriteLine("Difference: " + mc.subs(4, 2));
            Console.WriteLine("Product: " + mc.mult(4, 2));
            Console.WriteLine("Division: " + mc.div(4, 2));
            Console.ReadKey();
        }
    }
}
