using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
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
            bool sufficientBalance = DeductCostFromBalance(slot);
            if (!sufficientBalance)
            {
                Console.WriteLine("Insufficient balance.");
                return;
            }
            bool slotDecreased = DecreaseSlot(slot);
            if (!slotDecreased)
            {
                Console.WriteLine("Slot is out of stock.");
                return;
            }
            Console.WriteLine($"Item name: {slotItems[slot].Name}");
            Console.WriteLine($"Item price: {slotItems[slot].Price}");
            Console.WriteLine($"Balance remaining: {this.Balance}");
            slotItems[slot].DispenseMessage();
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
    }
}
