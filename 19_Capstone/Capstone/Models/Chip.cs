using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Chip : VendingItem
    {
        public Chip(string name, double price) : base(name, price)
        {
        }

        public override void DispenseMessage()
        {
            Console.WriteLine("Crunch Crunch, Yum!");
        }
    }
}
