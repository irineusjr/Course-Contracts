using System;
using System.Collections.Generic;
using System.Text;
using Contracts.Entities;
using Contracts.Entities.Exceptions;

namespace Contracts.Services
{
    class ProcessingService
    {
        public int NumberOfInstallments { get; private set; }

        public IPaymentService _paymentService;

        public ProcessingService()
        {
        }
        public ProcessingService(int numberOfInstallments, IPaymentService paymentService)
        {
            if (numberOfInstallments < 1)
            {
                throw new DomainException("Número de parcelas deve ser maior ou igual a 1");
            }
            else
            {
                NumberOfInstallments = numberOfInstallments;
                _paymentService = paymentService;
            }
        }
        
        public void ProcessContract(Contract contract)
        {
            double instValue = contract.TotalValue / NumberOfInstallments;
            for (int i = 1; i <= NumberOfInstallments; i++)
            {
                //contract.Installments.Add(new Installment(contract.Date.AddMonths(i), contract.TotalValue / NumberOfInstallments));
                contract.Installments.Add(new Installment(contract.Date.AddMonths(i), _paymentService.ProcessPayment(instValue, contract.Date, contract.Date.AddMonths(i))));
            }
        }


   
    }
}
