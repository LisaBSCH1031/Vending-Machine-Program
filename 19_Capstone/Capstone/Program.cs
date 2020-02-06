using Capstone.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();

            vendingMachine.StockItems();

            vendingMachine.DisplayCurrentInventory();

            // manual dispense test
            vendingMachine.Balance = 100.00;
            vendingMachine.Dispense("A1");
            vendingMachine.Dispense("A1");
            vendingMachine.Dispense("A1");
            vendingMachine.Dispense("A1");
            vendingMachine.Dispense("A1");
            vendingMachine.Dispense("A1");
            vendingMachine.Dispense("A1");
            vendingMachine.DisplayCurrentInventory();
        }
    }
}
