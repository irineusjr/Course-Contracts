using Contracts.Entities;
using Contracts.Entities.Exceptions;

namespace Contracts.Services
{
    class ProcessingService
    {

        private IPaymentService _paymentService;

        public ProcessingService()
        {
        }
        public ProcessingService(IPaymentService paymentService)
        {       
            _paymentService = paymentService;
        }
        
        public void ProcessContract(Contract contract, int numberOfInstallments)
        {
            double instValue = contract.TotalValue / numberOfInstallments;
            for (int i = 1; i <= numberOfInstallments; i++)
            {
                //contract.Installments.Add(new Installment(contract.Date.AddMonths(i), contract.TotalValue / NumberOfInstallments));
                contract.Installments.Add(new Installment(contract.Date.AddMonths(i), _paymentService.ProcessPayment(instValue, i)));
            }
        }


   
    }
}
