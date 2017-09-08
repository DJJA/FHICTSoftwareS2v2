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
            GraafAlgoritme.GetShortestRoute(GraafAlgoritme.graaf1, 'A', 'F');

            Console.ReadLine();
        }
    }
}
