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
            //var productsSorted = new List<Product>();
            //while (mProducts.Count > 0)
            //{
            //    productsSorted.Add(GiveMaximumPrice(mProducts));
            //    mProducts.RemoveAt(mProducts.IndexOf(productsSorted[productsSorted.Count - 1]));
            //}
            //mProducts = productsSorted;
            BubleSort2();
        }

        private void BubleSort()
        {
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int i = 1; i < mProducts.Count; i++)
                {
                    if (mProducts[i].Price < mProducts[i - 1].Price)
                    {
                        SwapTwoListItems(mProducts, i, i - 1);
                        swapped = true;
                    }
                }
            }
        }

        private void BubleSort2()
        {
            for (int i = 1; i < mProducts.Count; i++)
            {
                if (mProducts[i].Price < mProducts[i - 1].Price)
                {
                    SwapTwoListItems(mProducts, i, i - 1);
                    i = 0;
                }
            }
        }

        private void SwapTwoListItems(List<Product> list, int index1, int index2)
        {
            var p = list[index1];
            list[index1] = list[index2];
            list[index2] = p;
        }
    }
}
