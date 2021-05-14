using MovieTickets.CostAnalyzer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MovieTickets.CostAnalyzer
{
    public class Process
    {
        private readonly double childTicketPrice = 5;
        private readonly double teenTicketPrice = 12;
        private readonly double adultTicketPrice = 25;
        private readonly double seniorConcession = 0.3;
        private readonly double childConcession = 0.25;

        public void CostAnalyzerAsync(string inputFile)
        {
            var inputJson = File.ReadAllText(inputFile);
            var transactions = JsonConvert.DeserializeObject<List<Transaction>>(inputJson);

            Calculate(transactions);
        }

        public void Calculate(List<Transaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                Console.WriteLine("\n## Transaction {0} ##", transaction.TransactionId);

                Tuple<int, double> childCost = MathHelper.CalculateCosts(transaction, childTicketPrice, CustomerType.Child, childConcession);
                Tuple<int, double> teenCost = MathHelper.CalculateCosts(transaction, teenTicketPrice, CustomerType.Teen);
                Tuple<int, double> adultCost = MathHelper.CalculateCosts(transaction, adultTicketPrice, CustomerType.Adult);
                Tuple<int, double> seniorCost = MathHelper.CalculateCosts(transaction, adultTicketPrice, CustomerType.Senior, seniorConcession);

                double total = 0;
                if (adultCost.Item1 > 0)
                    total += WriteToConsole(adultCost.Item1, adultCost.Item2, CustomerType.Adult);

                if (childCost.Item1 > 0)
                    total += WriteToConsole(childCost.Item1, childCost.Item2, CustomerType.Child);

                if (teenCost.Item1 > 0)
                    total += WriteToConsole(teenCost.Item1, teenCost.Item2, CustomerType.Teen);

                if (seniorCost.Item1 > 0)
                    total += WriteToConsole(seniorCost.Item1, seniorCost.Item2, CustomerType.Senior);

                Console.WriteLine("\nProjected total cost: ${0}", total);
            }
        }

        private double WriteToConsole(int count, double price, CustomerType type)
        {
            Console.WriteLine("{0} ticket x {1}: ${2}", type, count, price);
            return price;
        }
    }
}
