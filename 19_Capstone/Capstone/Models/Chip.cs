using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Chip : VendingItem
    {
        public Chip(string name, double price) : base(name, price)
        {
            this.Color = ConsoleColor.Yellow;
        }

        public override void DispenseMessage()
        {
            Console.ForegroundColor = this.Color;
            Console.WriteLine("Crunch Crunch, Yum!");
            Console.ResetColor();
        }
    }
}
