using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ReferenceTest
    {
        public static void Execute()
        {
            var list = new List<int>()
            {
                1,2,3,4,5,6,7,8,9
            };

            Console.WriteLine("Before operation: (list)");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            var newList = new List<int>();
            newList.AddRange(list);
            newList.Add(99);
            newList.Add(99);
            newList.Add(99);
            newList.Add(99);
            newList.Add(99);


            Console.WriteLine("After operation: (list)");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("After operation: (newList)");
            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Adding items to old list:");
            list.Add(100);
            list.Add(100);
            list.Add(100);
            list.Add(100);
            list.Add(100);
            list.Add(100);
            list.Add(100);
            list.Add(100);
            list.Add(100);
            list.Add(100);
            list.Add(100);

            Console.WriteLine("After operation: (list)");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("After operation: (newList)");
            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
