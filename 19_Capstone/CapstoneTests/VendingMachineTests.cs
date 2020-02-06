using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void StockItemsTest()
        {
            VendingMachine vm = new VendingMachine();

            int expected = 4 * 4 * 5; // expected number of items in slotQuantities

            vm.StockItems();

            int actual = 0;

            foreach (var item in vm.slotQuantities)
            {
                actual += item.Value;
            }

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DispenseTest()
        {
            VendingMachine vm = new VendingMachine();

            double expected = 100 - 3.05;

            vm.Balance = 100.0;
            vm.StockItems();

            vm.Dispense("A1");
            double actual = vm.Balance;

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(1, 0.0, 1.0)]
        [DataRow(1, 100.0, 101.0)]
        [DataRow(3, 5.10, 5.10)]
        public void FeedMoneyTest(int bill, double startBal, double expected)
        {
            VendingMachine vm = new VendingMachine();

            vm.Balance = startBal;

            vm.FeedMoney(bill);

            double actual = vm.Balance;

            Assert.AreEqual(expected, actual);
        }
    }
}
