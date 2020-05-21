using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Contracts.Entities
{
    class Contract
    {
        public int Number { get; private set; }
        public DateTime Date { get; private set; }
        public double TotalValue { get; private set; }

        public List<Installment> Installments { get; private set; } = new List<Installment>();

        public Contract()
        {
        }
        public Contract(int number, DateTime date, double totalValue)
        {
            Number = number;
            Date = date;
            TotalValue = totalValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Installments:");
            foreach (Installment inst in Installments)
            {
                sb.AppendLine(inst.DueDate.ToString("dd/MM/yyyy") + " - " + inst.Value.ToString("F2", CultureInfo.InvariantCulture));
            }
            return sb.ToString();
        }
    }
}
