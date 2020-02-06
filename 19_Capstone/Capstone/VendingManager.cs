using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingManager
    {

        public void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            Console.WriteLine();
        }

        public void Run()
        {
            VendingMachine vm = new VendingMachine();
            vm.StockItems();
            DisplayMainMenu();
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    vm.DisplayCurrentInventory();
                    break;
                case "2":
                    DisplayPurchaseMenu(vm);
                    break;
                case "3":
                    Console.WriteLine("Enjoy your treat!");
                    return;
                case "4": //TODO: Add sales report
                    break;
                default:
                    break;
            }
        }

        public void DisplayPurchaseMenu(VendingMachine vm)
        {
            Console.Clear();
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine();
            Console.WriteLine($"Current Money Provided: {vm.Balance}");
        }


    }
}
