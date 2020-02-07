using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Drink : VendingItem
    {
        public Drink(string name, double price) : base(name, price)
        {
            this.Color = ConsoleColor.Red;
        }

        public override void DispenseMessage()
        {
            Console.ForegroundColor = this.Color;
            Console.WriteLine("Glug Glug, Yum!");
            Console.ResetColor();
        }
    }
}
