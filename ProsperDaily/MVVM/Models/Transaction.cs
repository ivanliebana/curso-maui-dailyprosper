﻿using Humanizer;
using ProsperDaily.Abstractions;

namespace ProsperDaily.MVVM.Models
{
    public class Transaction : TableData
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool Income { get; set; }
        public DateTime OperationDate { get; set; }
        public string HumanDate
        {
            get
            {
                return OperationDate.Humanize();
            }
        }
    }
}
