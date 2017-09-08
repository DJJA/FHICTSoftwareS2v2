using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class Fibonacci
    {
        private List<int> mFibonacciList = new List<int>()
        {
            1,2
        };

        public void Execute(int numberCount)
        {
            mFibonacciList.Add(mFibonacciList[mFibonacciList.Count - 1] + mFibonacciList[mFibonacciList.Count - 2]);
            if(mFibonacciList.Count < )
        }
    }
}