using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodOverriding
{
    class baseclass
    {
        public virtual void show()
        {
            Console.WriteLine("Method of base class");
        }
    }


    class deriveclass : baseclass
    {
        public override void show()
        {
            base.show(); //Calls the method of base/parent class
            Console.WriteLine("Method of derived class");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            deriveclass dc = new deriveclass();
            dc.show();
            Console.ReadKey();
        }
    }
}
