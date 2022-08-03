using System;
using System.Linq;
using System.Collections.Generic;

namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] grades = {32,33,34,35,36,37,38,39,40};

            foreach (int n in grades)
            {
                    if (n >= 38 && n % 5 >= 3)
                    {
                        Console.WriteLine(n + (5 - (n % 5)));
                    }
                    else
                    {
                        Console.WriteLine(n);
                    }
            }
        }
    }
}



/**class Solution
{
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < n; a0++)
        {
            int grade = Convert.ToInt32(Console.ReadLine());
            int final = 0;
            int next = ((grade / 5) + 1) * 5;
            
            if (next - grade >= 3 || grade < 38)
                final = grade;
            else
                final = next;
                Console.WriteLine(final);
        }
    }
}
**/
