using Capstone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Figgle;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            SetRandomColor();
            Console.WriteLine(FiggleFonts.Standard.Render("Vending Machine!"));
            Console.WriteLine($"{"                              Press enter to begin.", -20}");
            Console.ReadLine();
            Console.ResetColor();
            VendingManager vmr = new VendingManager();
            vmr.Run();
        }

        static public void SetRandomColor()
        {
            Array colors = Enum.GetValues(typeof(ConsoleColor));
            Random rand = new Random();
            int ix = rand.Next(1, colors.Length);
            ConsoleColor color = (ConsoleColor)colors.GetValue(ix);
            Console.ForegroundColor = color;
        }
    }
}
