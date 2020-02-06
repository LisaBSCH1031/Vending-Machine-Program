using System;
using System.Collections.Generic;
using System.IO;
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
                        SalesReport(vm);
                        Console.WriteLine("Sales report generated.\r\n");
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
        public void SalesReport(VendingMachine vm)
        {
            string body = string.Empty;
            double totalSales = 0;
            string timeStamp = DateTime.Now.ToString();
            timeStamp = timeStamp.Replace("/", "_");
            timeStamp = timeStamp.Replace(":", "_");
            timeStamp = timeStamp.Replace(" ", "-");
            string path = $"{timeStamp} OutputSalesReport.txt";
            foreach(var kvp in vm.slotQuantities)
            {
                body += ($"{vm.slotItems[kvp.Key].Name}|{5 - vm.slotQuantities[kvp.Key]} \n");
                totalSales += vm.slotItems[kvp.Key].Price * (5 - vm.slotQuantities[kvp.Key]);
            }
            body += ($"\r\n Total Sales: {totalSales:C}");
            using(StreamWriter sr = new StreamWriter(path))
            {
                sr.Write(body);
            }
        }
        

    }
}
