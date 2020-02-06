using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            public void StockItems()
            {
                //read csv file and split by line
                string filename = "vendingmachine.csv";
                List<string> allWords = new List<string>();
                using (StreamReader sr = new StreamReader(filename))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] words = line.Split("\n");
                        allWords.AddRange(words);

                    }
                }
                //join lines with ',' and then split and create into array
                string newWordStr = string.Join(",", allWords);
                string[] splitByLine = newWordStr.Split(",");

                //loop through and assign array values to variables
                for (int i = 1; i < splitByLine.Length - 1; i++)
                {
                    string slot = splitByLine[0];
                    string itemName = splitByLine[1];
                    string itemPrice = splitByLine[2];
                    double itemPriceInt = double.Parse(itemPrice);
                    string itemType = splitByLine[3];
                }
            }




        }
    }
}
