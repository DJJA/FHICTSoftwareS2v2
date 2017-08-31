using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefening1
{
    public class Order
    {
        private List<Product> mProducts = new List<Product>();

        public List<Product> Products
        {
            get { return mProducts; }
        }


        public void AddItem(Product p)
        {
            mProducts.Add(p);
        }

        public void AddItems(List<Product> products)
        {
            mProducts.AddRange(products);
        }

        public Double GiveMaximumPrice()
        {
            return GiveMaximumPrice(mProducts).Price;
        }

        private Product GiveMaximumPrice(List<Product> products)
        {
            Product mostExpensive = new Product() { Price = 0 };
            foreach (var product in products)
            {
                if (mostExpensive.Price < product.Price)
                    mostExpensive = product;
            }
            return mostExpensive;
        }

        public Double GiveAveragePrice()
        {
            Double sum = 0;
            foreach (var product in mProducts)
            {
                sum += product.Price;
            }
            return Math.Round(sum / mProducts.Count, 2);
        }

        public List<Product> GetAllProducts(Double minimumPrice)
        {
            var products = new List<Product>();
            foreach (var product in mProducts)
            {
                if (product.Price >= minimumPrice)
                    products.Add(product);
            }
            return products;
        }

        public void SortProductsByPrice()
        {
            var productsSorted = new List<Product>();
            while(mProducts.Count > 0)
            {
                productsSorted.Add(GiveMaximumPrice(mProducts));
                mProducts.RemoveAt(mProducts.IndexOf(productsSorted[productsSorted.Count - 1]));
            }
            mProducts = productsSorted;
        }
    }
}
