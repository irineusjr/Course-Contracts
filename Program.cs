using System;
using Contracts.Entities;
using Contracts.Services;
using Contracts.Entities.Exceptions;
using System.Globalization;

namespace Contracts
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter contract data");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Date: ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.Write("Contract Value: ");
                double totalValue = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Enter number of installments: ");
                int numberOfInstallments = int.Parse(Console.ReadLine());

                Contract contract = new Contract(number, date, totalValue);
                ProcessingService processingService = new ProcessingService(numberOfInstallments, new PayPalService(1.0,2.0));

                processingService.ProcessContract(contract);

                Console.WriteLine(contract.ToString());
            }
            catch (DomainException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
