using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyApplication
{    
    class Program
    {
        static void Main(string[] args)
        {
            int i = 9;
            double j = 0.2;
            Console.WriteLine(++i/j-i++);

        }   
    }                      
}