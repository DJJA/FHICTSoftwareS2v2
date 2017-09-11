using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var routes = GraafAlgoritme.GetPossibleRoutes(GraafAlgoritme.graaf1, 'A', 'F');
            var routes2 = GraafAlgoritme.GetPossibleRoutes(GraafAlgoritme.graaf1WithDirections, 'A', 'F');

            GraafAlgoritme.BubleSortRoutes(routes);
            GraafAlgoritme.BubleSortRoutes(routes2);

            Console.WriteLine("Possible routes without direction:");
            foreach (var route in routes)
            {
                Console.WriteLine(route.ToShortString());
            }

            Console.WriteLine();
            Console.WriteLine("Possible routes with direction:");
            foreach (var route in routes2)
            {
                Console.WriteLine(route.ToShortString());
            }


            var routes3 = GraafAlgoritme.Get10ShortestRoutes(GraafAlgoritme.GetPossibleRoutes(GraafAlgoritme.graaf2, 'D', 'T'));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("10 Shortest routes (graaf2):");
            foreach (var route in routes3)
            {
                Console.WriteLine(route.ToShortString());
            }
            foreach (var route in routes3)
            {
                Console.WriteLine(route);
            }


            var routes4 = GraafAlgoritme.GetPossibleRoutes(GraafAlgoritme.graaf1WithDirections, 'B', 'D');
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Possible routes (graaf1 w/ direction):");
            foreach (var route in routes4)
            {
                Console.WriteLine(route);
            }

            Console.WriteLine("Fibunacci:");
            var list = Fibonacci.GetFibonacciSequence(null, 4000000);
            list = Fibonacci.GetEvenNumbers(list);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
