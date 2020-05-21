using System;

namespace Contracts.Services
{
    class PayPalService : IPaymentService
    {
        public double MonthlyInterest { get; private set; }
        public double PaymentFee { get; private set; }

        public PayPalService(double monthlyInterest, double paymentFee)
        {
            MonthlyInterest = monthlyInterest;
            PaymentFee = paymentFee;
        }

        public double ProcessPayment(double value, DateTime contractDate, DateTime dueDate)
        {
            int monthNumber = dueDate.Year == contractDate.Year
                ? dueDate.Month - contractDate.Month
                : dueDate.Month + ((dueDate.Year - contractDate.Year)*12) - contractDate.Month;
            double paymentValue = value * (1 + ((MonthlyInterest / 100) * monthNumber));
            paymentValue += paymentValue * (PaymentFee / 100);
            return paymentValue;
        }
    }
}
