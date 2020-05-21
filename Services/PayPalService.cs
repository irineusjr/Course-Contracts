using System;

namespace Contracts.Services
{
    class PayPalService : IPaymentService
    {
        private const double MonthlyInterest = 1.0;
        private const double PaymentFee = 2.0;

        public double ProcessPayment(double value, int monthNumber)
        {
            double paymentValue = value * (1 + ((MonthlyInterest / 100) * monthNumber));
            paymentValue += paymentValue * (PaymentFee / 100);
            return paymentValue;
        }
    }
}
