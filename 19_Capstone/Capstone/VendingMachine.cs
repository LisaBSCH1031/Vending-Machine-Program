using Capstone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {
        /// <summary>
        /// Current balance for each transaction. Balance should be cleared at the end of the transaction by dispensing change.
        /// </summary>
        public double Balance { get; set; } = 0.0;

        /// <summary>
        /// Dictionary containing the current quantity in each slot. 
        /// </summary>
        public Dictionary<string, int> slotQuantities = new Dictionary<string, int>();

        /// <summary>
        /// Dictionary containing the item in each slot.
        /// </summary>
        public Dictionary<string, VendingItem> slotItems = new Dictionary<string, VendingItem>();

        /// <summary>
        /// Dispense an item in the specified slot. If the slot is out of stock, print a message to that effect.
        /// </summary>
        /// <param name="slot">The slot to be dispensed from.</param>
        public void Dispense(string slot)
        {
            Console.WriteLine($"Attempting to dispense item in slot {slot}...");
            bool sufficientBalance = DeductCostFromBalance(slot);
            if (!sufficientBalance)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }
            bool slotDecreased = DecreaseSlot(slot);
            if (!slotDecreased)
            {
                Console.WriteLine($"Slot {slot} is out of stock.\r\n");
                return;
            }
            Console.WriteLine($"Item name: {slotItems[slot].Name}");
            Console.WriteLine($"Item price: {slotItems[slot].Price:C}");
            Console.WriteLine($"Balance remaining: {this.Balance:C}");
            slotItems[slot].DispenseMessage();
            Console.WriteLine();
        }

        /// <summary>
        /// Deducts the cost of the item in a particular slot from the current balance, unless the balance is insufficient.
        /// </summary>
        /// <param name="slot">Slot to get the price of.</param>
        /// <returns>Returns true if the cost was successfully deducted from the balance.</returns>
        private bool DeductCostFromBalance(string slot)
        {
            bool sufficientBalance = false;
            double itemCost = slotItems[slot].Price;
            if (this.Balance >= itemCost)
            {
                sufficientBalance = true;
                this.Balance -= itemCost;
            }
            return sufficientBalance;
        }

        /// <summary>
        /// Decrease the quantity of items in the specified slot, if there is anything in the slot.
        /// </summary>
        /// <param name="slot">The slot to be decreased.</param>
        /// <returns>Returns true if the slot was successfully decreased, false otherwise.</returns>
        public bool DecreaseSlot(string slot)
        {
            bool slotDecreased = false;
            int currQuant = GetCurrentSlotQuantity(slot);
            if (currQuant > 0)
            {
                slotQuantities[slot] -= 1;
                slotDecreased = true;
            }
            return slotDecreased;
        }

        /// <summary>
        /// Take the current balance and return it as change. Also sets the current balance to zero.
        /// </summary>
        /// <param name="balance">Current transaction balance.</param>
        /// <returns>Change to be dispensed.</returns>
        public double GiveChange(double balance) // TODO: change needs to be given in coins
        {
            double change = balance;
            this.Balance = 0.0;
            return change;
        }

        /// <summary>
        /// Get the quantity of items in the specified slot.
        /// </summary>
        /// <param name="slot">The slot to check the quantity of.</param>
        /// <returns>The quantity of items left in the slot.</returns>
        public int GetCurrentSlotQuantity(string slot)
        {
            int quantity = slotQuantities[slot];
            return quantity;
        }

        /// <summary>
        /// Displays the current inventory.
        /// </summary>
        public void DisplayCurrentInventory()
        {
            foreach (var item in this.slotItems)
            {
                Console.WriteLine($"Slot: {item.Key}, Item: {item.Value.Name}, Quantity: {this.slotQuantities[item.Key]}");
            }
            Console.WriteLine();
        }


        /// <summary>
        /// Stocks the vending machine with the items in the 'vendingmachine.csv' file.
        /// </summary>
        public void StockItems()
        {
            //read csv file and split by line
            string filename = "vendingmachine.csv";
            List<string> allWords = new List<string>();
            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] words = line.Split("\n");
                    allWords.AddRange(words);

                }
            }
            //join lines with ',' and then split and create into array
            string newWordStr = string.Join(",", allWords);
            string[] splitByLine = newWordStr.Split(",");

            //loop through and assign array values to variables
            for (int i = 0; i < splitByLine.Length; i++)
            {
                string[] splitByPipe = splitByLine[i].Split("|");
                string slot = splitByPipe[0];
                string itemName = splitByPipe[1];
                string itemPrice = splitByPipe[2];
                double itemPriceInt = double.Parse(itemPrice);
                string itemType = splitByPipe[3];
                slotQuantities[slot] = 5;

                // make a new VendingItem of the proper type to hold the data
                switch (itemType)
                {
                    case "Candy":
                        slotItems[slot] = new Candy(itemName, itemPriceInt);
                        break;
                    case "Chip":
                        slotItems[slot] = new Chip(itemName, itemPriceInt);
                        break;
                    case "Drink":
                        slotItems[slot] = new Drink(itemName, itemPriceInt);
                        break;
                    case "Gum":
                        slotItems[slot] = new Gum(itemName, itemPriceInt);
                        break;
                    default:
                        break;
                }
            }
        }

        public void FeedMoney(int bill)
        {
            switch (bill)
            {
                case 1:
                    this.Balance += 1.0;
                    break;
                case 2:
                    this.Balance += 2.0;
                    break;
                case 5:
                    this.Balance += 5.0;
                    break;
                case 10:
                    this.Balance += 10.0;
                    break;
                case 20:
                    this.Balance += 20.0;
                    break;
                case 50:
                    this.Balance += 50.0;
                    break;
                case 100:
                    this.Balance += 100.0;
                    break;
                default:
                    Console.WriteLine("Error: invalid bill. A valid dollar bill must be entered.");
                    break;
            }
        }
    }
}
