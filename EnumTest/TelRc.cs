using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumTest
{
    public class TelRc
    {
          public enum CheckResult : byte
          {                                                                  
                Normal = 0,                                                      
                Error = 0xff                                                       
          }
        public enum CheckResultWithInt : int
        {
            Normal = 0,
            Error = 1
        }
    }
}
