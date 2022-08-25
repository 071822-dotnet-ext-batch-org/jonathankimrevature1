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
            int[] values = {1,2,2,3,1,2};

            List<int> uniqVal = new List<int>();
            int startUniq = -1;

            for (int i = 0; i<values.Length;i++)
            {
                var query = values.DistinctBy(p => p.Id);

                //var result = values.Count(x => x == values[i]);
                //Console.WriteLine(result);
            }  

        }
    }
}


/**
            int modeElement = 0;
            int modeCount = 0;

            for (int i=0;i<values.Count();i++)
            {
                int tempmodeElement = values[i];
                int tempmodeCount = 0;
                for (int p=0;p<values.Count();p++)
                    if(values[p]==tempmodeElement)
                        tempmodeCount++;
                if (tempmodeCount>modeCount)
                {
                    modeElement = tempmodeElement;
                    modeCount = tempmodeCount;
                }
            }

            Console.WriteLine("Mode:"+modeElement);
            Console.WriteLine("Mode Count:"+modeCount);
            


            int plusOne = modeElement + 1;
            int plusOneCount = 0;
            foreach (int n in values)
            {
                if (n == plusOne)
                {
                    plusOneCount++;
                }
            }

            int minusOne = modeElement - 1;
            int minusOneCount = 0;
            foreach (int n in values)
            {
                if (n == minusOne)
                {
                    minusOneCount++;
                }
            }
            
            int modeTwo = 0;
            int modeThree = 0;

            if(plusOneCount > minusOneCount)
            {
                modeTwo = plusOne;
            }
            if(minusOneCount > plusOneCount)
            {
                modeTwo = minusOne;
            }
            if(plusOneCount == minusOneCount)
            {
                modeTwo = plusOneCount;
                modeThree = minusOneCount;
            }

            Console.WriteLine("Mode2:"+modeTwo);


            List<int> longestSubArray = new List<int>();

            foreach (int n in values)
            {
                if (n == modeElement || n == modeTwo || n == modeThree)
                {
                    longestSubArray.Add(n);
                }
            }

            Console.WriteLine(longestSubArray.Count());
        }  
    }                      
}**/