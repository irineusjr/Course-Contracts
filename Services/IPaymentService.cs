using System;

namespace Contracts.Services
{
    interface IPaymentService
    {
        public double ProcessPayment(double value, int months);
    }
}
