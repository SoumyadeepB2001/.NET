using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exceptions
{
    //Exception: Error that arise during the runtime

    class Program
    {

        class myexceptionclass
        {
            public int div(int a, int b)
            {
                try
                {
                    return a / b;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                return 0;

            }
        }


        static void Main(string[] args)
        {

            myexceptionclass mce = new myexceptionclass();            
            Console.WriteLine(mce.div(1, 0));
            Console.WriteLine(mce.div(10, 2));
            Console.WriteLine("End of program");
            Console.ReadKey();
        }
    }
}
