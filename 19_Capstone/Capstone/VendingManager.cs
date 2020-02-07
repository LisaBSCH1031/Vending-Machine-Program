using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Figgle;

namespace Capstone
{
    public class VendingManager
    {

        public void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("Main Menu"));
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
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
            }
        }

        public void DisplayPurchaseMenu(VendingMachine vm)
        {
            Console.Clear();
            Console.WriteLine(FiggleFonts.Standard.Render("Purchase Menu"));
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
                        int amt;
                        bool didParseSucceed = int.TryParse(input, out amt);
                        if (!didParseSucceed)
                        {
                            Console.WriteLine("Invalid entry. Please try again.");
                            break;
                        }
                        vm.FeedMoney(amt);
                        break;
                    case "2":
                        vm.DisplayCurrentInventory();
                        Console.WriteLine("Please enter a selection");
                        string input1 = Console.ReadLine().ToUpper();
                        vm.Dispense(input1);
                        
                        break;
                    case "3":
                        Console.WriteLine("Thank you for your patronage!");
                        (int numQ, int numD, int numN) = ChangeIntoQuarDimNic(vm);
                        Console.WriteLine($"Your change is {numQ} Quarters, {numD} Dimes, and {numN} Nickels.");
                        return;
                    default:
                        break;
                }
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();

            }
        }

        public (int Q, int D, int N) ChangeIntoQuarDimNic(VendingMachine vm)
        {
            double change = vm.GiveChange(vm.Balance);
            int numQ = 0, numD = 0, numN = 0;
            int intCents = GetIntCents(change);
            int remainder;
            (numQ, remainder) = GetQuarters(intCents);
            (numD, numN) = GetDimesNickels(remainder);
            return (numQ, numD, numN);
        }

        public int GetIntCents(double change)
        {
            double cents = change * 100;
            int result = (int)(Math.Round(cents));
            return result;
        }

        public (int numQ, int remainder) GetQuarters(int intCents)
        {
            int numQ = intCents / 25;
            int remainder = intCents % 25;
            return (numQ, remainder);
        }

        public (int numD, int numN) GetDimesNickels (int remainder)
        {
            int numD = 0, numN = 0;
            numD = remainder / 10;
            int remainder2 = remainder % 10;
            numN = remainder2 / 5;
            return (numD, numN);
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
