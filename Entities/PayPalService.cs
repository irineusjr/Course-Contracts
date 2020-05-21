using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Entities
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
            int monthNumber;
            if (dueDate.Year == contractDate.Year)
            {
                monthNumber = dueDate.Month - contractDate.Month;
            }
            else
            {
                monthNumber = dueDate.Month + ((dueDate.Year - contractDate.Year)*12) - contractDate.Month;
            }
            double paymentValue = value * (1 + ((MonthlyInterest / 100) * monthNumber));
            paymentValue += paymentValue * (PaymentFee / 100);
            return paymentValue;
        }
    }
}
