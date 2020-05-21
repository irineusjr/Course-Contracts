﻿using System;

namespace Contracts.Entities
{
    class Installment
    {
        public DateTime DueDate { get; private set; }
        public double Value { get; private set; }

        public Installment()
        {
        }
        public Installment(DateTime dueDate, double value)
        {
            DueDate = dueDate;
            Value = value;
        }


    }
}
