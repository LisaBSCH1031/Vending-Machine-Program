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

            // TODO: USE FOR DISPLAYING CURRENT INVENTORY
            foreach (var item in vendingMachine.slotItems)
            {
                Console.WriteLine($"Slot: {item.Key}, Item: {item.Value.Name}, Quantity: {vendingMachine.slotQuantities[item.Key]}");
            }

        }
    }
}
