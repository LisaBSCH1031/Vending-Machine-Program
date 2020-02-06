using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Drink : VendingItem
    {
        public Drink(string name, double price) : base(name, price)
        {
        }

        public override void DispenseMessage()
        {
            Console.WriteLine("Glug Glug, Yum!");
        }
    }
}
