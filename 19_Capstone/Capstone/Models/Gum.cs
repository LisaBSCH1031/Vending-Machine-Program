using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    class Gum : VendingItem
    {
        public Gum(string name, double price) : base(name, price)
        {
            this.Color = ConsoleColor.Green;
        }

        public override void DispenseMessage()
        {
            Console.ForegroundColor = this.Color;
            Console.WriteLine("Chew Chew, Yum!");
            Console.ResetColor();
        }
    }
}
