using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var byteOk = TelRc.CheckResultWithInt.Error.ToString();
            var type = byteOk.GetType();
           
        }
    }
}
