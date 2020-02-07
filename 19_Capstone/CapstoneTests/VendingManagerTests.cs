using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class VendingManagerTests
    {


        [DataTestMethod]
        [DataRow(20, new int[] { 80, 0, 0 })]
        [DataRow(20.10, new int[] { 80, 1, 0 })]
        [DataRow(20.05, new int[] { 80, 0, 1 })]
        [DataRow(0, new int[] { 0, 0, 0 })]
        [DataRow(.30, new int[] { 1, 0, 1 })]
        [DataRow(.60, new int[] { 2, 1, 0 })]
        [DataRow(.75, new int[] { 3, 0, 0 })]
        [DataRow(.65, new int[] { 2, 1, 1 })]
        public void ChangeIntoQuarDimNicTest(double balance, int[] coins)
        {
            VendingMachine vm = new VendingMachine();
            vm.StockItems();
            vm.Balance = balance;
            VendingManager vmgr = new VendingManager();
                
            List<int> actual = new List<int>();
            int Q = 0;
            int D = 0;
            int N = 0;
            
            (Q, D, N) = vmgr.ChangeIntoQuarDimNic(vm);
            actual.Add(Q);
            actual.Add(D);
            actual.Add(N);
            List<int> expected = new List<int>();
            expected.AddRange(coins);
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
