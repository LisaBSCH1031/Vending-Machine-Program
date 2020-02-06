using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingManager
    {

        public void DisplayMainMenu()
        {
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            Console.WriteLine();
        }

        public void Run()
        {
            VendingMachine vm = new VendingMachine();
            vm.StockItems();
            while (true)
            {
                DisplayMainMenu(); //TODO: Add in Console.Clear's
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        vm.DisplayCurrentInventory();
                        break;
                    case "2":
                        EnterPurchaseMenu(vm);
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
        }

        public void DisplayPurchaseMenu(VendingMachine vm)
        {
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine();
            Console.WriteLine($"Current Money Provided: {vm.Balance:C}");
        }

        public void EnterPurchaseMenu(VendingMachine vm)
        {
            while (true)
            {
                DisplayPurchaseMenu(vm);
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        Console.WriteLine("Enter the amount you would like to add in whole dollars");
                        string input = Console.ReadLine();
                        int amt = int.Parse(input);
                        vm.FeedMoney(amt);
                        break;
                    case "2":
                        vm.DisplayCurrentInventory();
                        Console.WriteLine("Please enter a selection");
                        string input1 = Console.ReadLine();
                        vm.Dispense(input1);
                        break;
                    case "3":
                        Console.WriteLine("Thank you for your patronage!");
                        Console.WriteLine($"Your change is {vm.GiveChange(vm.Balance):C}."); 
                        return;
                    default:
                        break;
                }

            }
        }

    }
}
