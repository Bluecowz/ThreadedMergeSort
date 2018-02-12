using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace ThreadedMergeSort
{
    class MergeSort
    {
        private Random rand;

        public MergeSort()
        {
            rand = new Random();
        }

        public int[] Sort(int[] array)
        {
            if (array.Length <= 1)
                return array;

            int middle = rand.Next(array.Length);
            int[] derp1 = new int[middle];
            int[] derp2 = new int[array.Length - middle];

            int j = 0;
            for (int i = 0; i < middle; i++)
            {
                derp1[i] = array[j++];
            }

            for (int i = 0; j < array.Length; i++)
            {
                derp2[i] = array[j++];
            }

            Task<int[]> future1 = Task.Factory.StartNew<int[]>(() => Sort(derp1));
            Task<int[]> future2 = Task.Factory.StartNew<int[]>(() => Sort(derp2));

            derp1 = future1.Result;
            derp2 = future2.Result;
            return Task.Factory.StartNew<int[]>(() => Merge(derp1, derp2)).Result;
        }
        

        private int[] Merge(int[] left, int[] right)
        {
            int[] derp = new int[left.Length + right.Length];
            int i = 0, j = 0, k = 0;
            while((i < left.Length) && (k < right.Length))
            {
                if (left[i] < right[k])
                {

                    derp[j] = left[i];
                    i++;
                }
                else
                {
                    derp[j] = right[k];
                    k++;
                }
                j++;
            }
            while(i < left.Length)
            {
                derp[j] = left[i];
                j++; i++;
            }

            while(k < right.Length)
            { 
                derp[j] = right[k];
                j++; k++;
            }

            return derp;
        }
    }
}
