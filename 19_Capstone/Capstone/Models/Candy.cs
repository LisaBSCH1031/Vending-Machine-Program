using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Candy : VendingItem
    { 
        public Candy(string name, double price) : base(name, price)
        {
            this.Color = ConsoleColor.Blue;
        }

        public override void DispenseMessage()
        {
            Console.ForegroundColor = this.Color;
            Console.WriteLine("Munch Munch, Yum!");
            Console.ResetColor();
        }
    }
}
