
using System;

namespace Contracts.Entities
{
    interface IPaymentService
    {
        public double ProcessPayment(double value, DateTime contractDate, DateTime dueDate);
    }
}
