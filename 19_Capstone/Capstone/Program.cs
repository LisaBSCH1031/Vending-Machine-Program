using Capstone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Figgle;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FiggleFonts.Standard.Render("Vending Machine!"));
            Console.WriteLine("Press enter to begin.");
            Console.ReadLine();
            VendingManager vmr = new VendingManager();
            vmr.Run();
        }
    }
}
