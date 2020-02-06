using Capstone.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingManager vmr = new VendingManager();
            vmr.Run();
        }
    }
}
