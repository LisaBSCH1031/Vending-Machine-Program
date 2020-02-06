﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Candy : VendingItem
    {
        public Candy(string name, double price) : base(name, price)
        {
        }

        public override void DispenseMessage()
        {
            Console.WriteLine("Munch Munch, Yum!");
        }
    }
}
