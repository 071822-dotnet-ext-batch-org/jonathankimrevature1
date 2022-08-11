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
            using(var source = new HttpClient())
            {
                var endpoint = new Uri("http://api.icndb.com/jokes/random"); //assigned source url to variable endpoint
                var endpoint2 = new Uri("http://api.icndb.com/jokes/random?limitTo=[nerdy]");
                var result = source.GetAsync(endpoint).Result; //output the results from the endpoint
                var result2 = source.GetAsync(endpoint2).Result;
                var json = result.Content.ReadAsStringAsync().Result; //converted the result to json
                var json2 = result2.Content.ReadAsStringAsync().Result;
                Console.WriteLine(json); //prints json script
                Console.WriteLine();//make a space
                Console.WriteLine(json2);
            }

        }   

    }                      
}