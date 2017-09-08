using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Sorting
    {
        public static void InsertionSort(int[] arr)
        {
            int curInsertionPoint = 0;  // current insertion point
            int iSmallest = -1;
            while (curInsertionPoint < (arr.Length - 1))
            {
                for (int i = curInsertionPoint; i < arr.Length; i++)
                {
                    if (iSmallest == -1)
                        iSmallest = i;
                    else if (arr[iSmallest] > arr[i])
                        iSmallest = i;
                }

                int temp = arr[curInsertionPoint];
                arr[curInsertionPoint] = arr[iSmallest];
                arr[iSmallest] = temp;

                curInsertionPoint++;
            }
        }
    }
}
