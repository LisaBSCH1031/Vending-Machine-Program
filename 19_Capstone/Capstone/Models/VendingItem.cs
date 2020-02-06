using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public abstract class VendingItem
    {
        public string Name { get; protected set; }
        public double Price { get; protected set; }
        public VendingItem(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
        public abstract void DispenseMessage();
    }
}
