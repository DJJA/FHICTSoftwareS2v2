using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 2, 6, 9, 3, 1 };

            Console.WriteLine("Unsorted:");
            foreach (var item in arr)
                Console.WriteLine(item);

            Sorting.InsertionSort(arr);

            Console.WriteLine("Sorted:");
            foreach (var item in arr)
                Console.WriteLine(item);

            Console.ReadLine();
        }


    }
}
