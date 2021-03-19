using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TupleSelfLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            (double a, int b) t1 = (4.1, 5);
            Console.WriteLine($"{t1.a}, {t1.b}");
            Console.ReadLine();
        }
    }
}
