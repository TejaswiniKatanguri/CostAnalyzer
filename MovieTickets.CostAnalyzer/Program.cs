using System;
using System.IO;

namespace MovieTickets.CostAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\transactions.json ";
            Process proc = new Process();
            proc.CostAnalyzerAsync(inputFile);

            Console.ReadLine();
        }
    }
}
