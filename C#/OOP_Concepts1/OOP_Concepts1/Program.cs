﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Concepts1
{

    class a
    {
        public void afunction()
        {
            Console.WriteLine("Function of class a");
        }
    }


    class b : a
    {
        public void bfunction()
        {
            Console.WriteLine("Function of class b");
        }
    }




    class myClass
    {
        public myClass(int a)
        {
            Console.WriteLine(a);
        }

        public void hello()
        {
            Console.WriteLine("Welcome Soumyadeep");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            //inheritance
            a aobj = new a();
            aobj.afunction();

            b bobj = new b();
            bobj.bfunction();
            bobj.afunction();



            //CONCEPT ABOUT CLASS AND OBJECTS
            //EARLY BINDING OR COMPILE TIME MEMORY ALLOCATION & LATE BINDING OR RUNTIME/ DYNAMIC MEMORY ALLOCATION

             myClass mc; //mc is named memory location
             mc = new myClass(1); // new is for DYNAMIC MEMORY ALLOCATION that is memory allocation during runtime
             mc.hello();
             //mc is a named memory location but it has no allocated memory. It is called a named memory location because in the future if the programmer allocates a memory for this object then the name of that location will be 'mc'. 
            //It is like naming a house before buying land plot for building it. So in the future when you will buy land to build the house you will already have a name for the house/land.

             myClass mc1;
             mc1 = mc;
             mc1.hello();

            Console.ReadKey();
        }
    }
}