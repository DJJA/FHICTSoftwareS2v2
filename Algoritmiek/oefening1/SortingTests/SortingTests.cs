using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Tests
{
    [TestClass()]
    public class SortingTests
    {
        [TestMethod()]
        public void InsertionSortTest()
        {
            // Vars
            var arr = new int[] { 2, 6, 9, 3, 1 };
            var expectedResult = new int[] { 1, 2, 3, 6, 9 };

            // Operation
            Sorting.InsertionSort(arr);

            // Check
            CollectionAssert.AreEqual(expectedResult, arr);
        }
    }
}