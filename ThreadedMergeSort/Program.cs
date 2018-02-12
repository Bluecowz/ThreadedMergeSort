using System;
using System.Diagnostics;

namespace ThreadedMergeSort
{
    class Program
    {

        static void Main(string[] args)
        {
            MergeSort sort = new MergeSort();
            Random rand = new Random();
            int[] derp = new int[rand.Next(1000000)];
            Debug.WriteLine("Size: " + derp.Length.ToString());
            for (int i = 0; i < derp.Length; i++)
                derp[i] = rand.Next(1000000);
            Debug.WriteLine("Done populating");
            derp = sort.Sort(derp);
            Test(derp);
            Debug.WriteLine("Success!");
        }

        private static void Test(int[] array)
        {
            
            for (int i = 1; i < array.Length; i++)
            {
                int one = array[i - 1];
                int two = array[i];
                if (one > two)
                    throw new Exception();
            }
        }
    }
}
