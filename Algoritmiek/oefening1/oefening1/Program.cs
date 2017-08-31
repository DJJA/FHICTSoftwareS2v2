using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefening1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 5;
            Console.WriteLine(i == 5 ? "ja, i is 5" : "nee, i is geen 5");

            var products = new List<Product>();
            products.Add(new Product() { Price = 3 });
            products.Add(new Product() { Price = 88.5 });
            products.Add(new Product() { Price = 3.75 });
            products.Add(new Product() { Price = 38 });
            products.Add(new Product() { Price = 36 });
            products.Add(new Product() { Price = 322 });
            products.Add(new Product() { Price = 33 });
            products.Add(new Product() { Price = 56 });
            products.Add(new Product() { Price = 76.6 });
            products.Add(new Product() { Price = 9 });
            products.Add(new Product() { Price = 007 });

            var order = new Order();
            order.AddItems(products);

            Console.WriteLine();
            Console.WriteLine("Prices: ");
            foreach (var item in order.Products)
            {
                Console.WriteLine("Price: {0} ", item.Price);
            }

            Console.WriteLine("Maximum Price is: {0}", order.GiveMaximumPrice());

            Console.WriteLine("Average Price is: {0}", order.GiveAveragePrice());

            Console.WriteLine("Sorted list:");
            order.SortProductsByPrice();
            foreach (var item in order.Products)
            {
                Console.WriteLine("Price: {0} ", item.Price);
            }


            Console.ReadLine();
        }
    }
}
