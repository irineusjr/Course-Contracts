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
                if (numberOfInstallments < 1)
                {
                    throw new DomainException("Número de parcelas deve ser maior ou igual a 1");
                }
                else
                {
                    Contract contract = new Contract(number, date, totalValue);
                    ProcessingService processingService = new ProcessingService(new PayPalService());

                    processingService.ProcessContract(contract, numberOfInstallments);

                    Console.WriteLine(contract);
                }
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
