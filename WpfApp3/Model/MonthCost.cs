using MvvmTest.Enum;
using System;

namespace MvvmTest.Model
{
    public class MonthCost
    {
        public MonthEnum Month { get; set; }

        public double CostMunber { get; set; }

        public DateTime CostDate { get; set; }

        public string Description { get; set; }
    }
}
