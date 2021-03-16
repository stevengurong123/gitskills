using System.Collections;
using System.Collections.Generic;

namespace MvvmTest.Model
{
    public class TotalCost
    {
        public string Year { get; set; }
        public List<MonthCost> MonthList { get; set; } = new List<MonthCost>();
    }
}
