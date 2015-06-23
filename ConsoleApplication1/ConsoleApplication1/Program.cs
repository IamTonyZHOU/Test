using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int k = 0; k < 100; k++)
            {
            
                //tth
                int AWinCount = 0;
                int BWinCount = 0;

                var resultStack = new List<bool>();

                for (int i = 0; i < 1000; i++)
                {
                    bool coinResult = RandomGenerator.GetCoin();

                    resultStack.Add(coinResult);
                    if (AWin(resultStack))
                    {
                        AWinCount++;
                        resultStack.Clear();
                    }
                    else if (BWin(resultStack))
                    {
                        BWinCount++;
                        resultStack.Clear();
                    }

                }

                Console.WriteLine("A win {0}, B win {1}", AWinCount, BWinCount);
            }
        }

        private static bool AWin(List<bool> result)
        {
            if (result.Count < 3)
                return false;

            var lastIndex = result.Count - 1;

            if (result[lastIndex-2] == true && result[lastIndex-1] == false && result[lastIndex] == false)
                return true;
            else
                return false;
        }

        private static bool BWin(List<bool> result)
        {
            if (result.Count < 3)
                return false;

            var lastIndex = result.Count - 1;

            if (result[lastIndex-2] == false && result[lastIndex-1] == false && result[lastIndex] == true)
                return true;
            else
                return false;
        }



    }

    public class RandomGenerator
    {
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static bool GetCoin()
        {
            lock (syncLock)
            { // synchronize
                return random.Next(2) == 0;
            }
        }
      
    }
}
