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
                        ChangeIntoQuarDimNic(vm);
                        return;
                    default:
                        break;
                }
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();

            }
        }

        public void ChangeIntoQuarDimNic(VendingMachine vm)
        {
            double change = vm.GiveChange(vm.Balance);
            int numQ = 0;
            int numD = 0;
            int numN = 0;
            int dollars = (int)change; //whole number
            numQ += dollars * 4; //number of quarters

            double cents = change - dollars; //amt of cents
            if (cents != 0.0)
            {
                cents = Math.Round(cents, 2); //amt of cents rounded to 2 places
                string centString = cents.ToString(); //cents into string
                string subCentTen = centString.Substring(2, 1); //isolate tens place
                string subCentFive = centString.Substring(3, 1); //isolate fives place
                if (cents % .25 == 0) //if cents 25, 20, 75
                {
                    numD = 0;
                    numN = 0;
                    numQ += (int)(cents / .25); //add that # of quarters to numQ
                }
                else if ((cents - .25) != 0) //if cents-25 has a balance and that balance 
                {
                    numQ += (int)(cents / 25); //add whole number to quarters
                    cents = (cents - 25);
                    string centString1 = cents.ToString(); //cents into string
                    string subCentTen1 = centString1.Substring(2, 1); //isolate tens place
                    string subCentFive1 = centString1.Substring(3, 1); //isolate fives place
                    if (subCentFive == "5")
                    {
                        numN = 1;
                    }
                    else
                    {
                        numN = 0;
                    }
                    numD = int.Parse(subCentTen);
                } 
            }
            Console.WriteLine($"Your change is {numQ} Quarters, {numD} Dimes, and {numN} Nickels totaling {change:C}.");
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
