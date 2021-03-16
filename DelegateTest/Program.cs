using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest
{
    public static class SimpleSort
    {
        /// <summary>
        /// array is a reference type
        /// </summary>
        /// <param name="items"></param>
        public static void BubbleSort(int [] items, Func<int, int, bool> sort)
        {
             int i, j, temp;
             if (items == null)
             {
                 return;
             }

             for ( i = items.Length-1; i >= 0; i --)
            {
                for (j=1; j <=i; j++)
                {
                    if (sort(items[j-1], items[j]))
                    {
                        temp = items[j - 1];
                        items[j - 1] = items[j];
                        items[j] = temp;
                    }
                }
            }
         }
    }

    public class TestA
    {
        
        public void Test(int []a)
        {
            a[0] = 1;
        }
    }

    class Program
    {
        delegate bool sort(int a ,int b);

        delegate int del(int i);

        public static bool cal(int a, int b)
        {
            return a > b;
        }
        static void Main(string[] args)
        {
            sort sort = (a1,b1) =>
            {
                return a1 > b1;
            };
            del del = (x) => x*x;
            TestA aa = new TestA();
            int[]a = {0,0};
            aa.Test(a);

            int[] items = new[] {1, 4, 2, 11, 7};

            SimpleSort.BubbleSort(items,sort);
        }
    }
}
