using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoResetEventTest
{
    class Program
    {
        private static AutoResetEvent event_1 = new AutoResetEvent(initialState: false);

        private static void Run()
        {
             AutoResetEvent event_2 = new AutoResetEvent(initialState: false);
          Console.WriteLine("State is be set;");
        }
        static void Main(string[] args)
        {
            Run();

            Console.WriteLine("end");
            Console.ReadLine();
        }
    }
}
