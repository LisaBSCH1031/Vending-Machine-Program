using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    class Gum : VendingItem
    {
        public Gum(string name, double price) : base(name, price)
        {
        }

        public override void DispenseMessage()
        {
            Console.WriteLine("Chew Chew, Yum!");
        }
    }
}
