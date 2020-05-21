
using System;

namespace Contracts.Services
{
    interface IPaymentService
    {
        public double ProcessPayment(double value, DateTime contractDate, DateTime dueDate);
    }
}
