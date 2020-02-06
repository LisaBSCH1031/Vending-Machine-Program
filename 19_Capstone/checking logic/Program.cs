using System;

namespace checking_logic
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = 20.34;
            int numQ = 0;
            int numD = 0;
            int numN = 0;
            int dollars = (int)change; //whole number
            numQ += dollars * 4; //number of quarters
            double cents = change - dollars; //amt of cents

            cents = Math.Round(cents, 2);
            string centString = cents.ToString();
            string subCentTen = centString.Substring(2, 1);
            Console.WriteLine(subCentTen);

        }
    }
}
