using Microsoft.VisualStudio.TestTools.UnitTesting;
using oefening1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefening1.Tests
{
    [TestClass()]
    public class OrderTests
    {
        //[TestMethod()]
        //public void SortProductsByPriceTest()
        //{
        //    // Vars
        //    var order = new Order();
        //    order.AddItem(new Product() { Price = 33.6 });
        //    order.AddItem(new Product() { Price = 44 });
        //    order.AddItem(new Product() { Price = 2.5 });
        //    order.AddItem(new Product() { Price = 723 });
        //    order.AddItem(new Product() { Price = 912 });

        //    var expectedResult = new List<Product>()
        //    {
        //        new Product(){Price = 2.5},
        //        new Product(){Price = 33.6},
        //        new Product(){Price = 44},
        //        new Product(){Price = 723},
        //        new Product(){Price = 912}
        //    };

        //    // Operation
        //    order.SortProductsByPrice();

        //    // Check
        //    //Assert.AreEqual(expectedResult, order.Products);
        //    CollectionAssert.AreEqual(expectedResult, order.Products);
        //    //Assert.IsTrue(order.Products.Equals(expectedResult));
        //}

        [TestMethod()]
        public void SortProductsByPriceTestV2()
        {
            // Vars
            var order = new Order();
            order.AddItem(new Product() { Price = 33.6 });
            order.AddItem(new Product() { Price = 44 });
            order.AddItem(new Product() { Price = 2.5 });
            order.AddItem(new Product() { Price = 723 });
            order.AddItem(new Product() { Price = 912 });



            var expectedResult = new List<double>()
            {
                2.5,
                33.6,
                44,
                723,
                912
            };

            // Operation
            order.SortProductsByPrice();

            var result = new List<double>();
            foreach (var item in order.Products)
            {
                result.Add(item.Price);
            }

            // Check
            CollectionAssert.AreEqual(expectedResult, result, "The list were not equal");
        }

        //[TestMethod()]
        //public void ListCheck()
        //{
        //    var expectedResult = new List<double>()
        //    {
        //        2.5,
        //        33.6,
        //        44,
        //        723,
        //        912
        //    };
        //    var result = new List<double>()
        //    {
        //        2.5,
        //        33.6,
        //        44,
        //        723,
        //        912
        //    };

        //    CollectionAssert.AreEqual(expectedResult, result);
        //}
    }
}