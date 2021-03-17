using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DelegateTest
{
    public static class SimpleSort<T> where T : IComparable, IFormattable, IConvertible, IComparable<Int32>, IEquatable<Int32>
    {
        /// <summary>
        /// array is a reference type
        /// </summary>
        /// <param name="items"></param>
        public static void BubbleSort(T[] items, Func<T, T, bool> sort)
        {
            int i, j;
            T temp;
            if (items == null)
            {
                return;
            }

            for (i = items.Length - 1; i >= 0; i--)
            {
                for (j = 1; j <= i; j++)
                {
                    if (sort(items[j - 1], items[j]))
                    {
                        temp = items[j - 1];
                        items[j - 1] = items[j];
                        items[j] = temp;
                    }
                }
            }
        }

        public static void TestDelegate(Delegate del)
        {
            //del.GetInvocationList()[0].DynamicInvoke(1, 2);
        }
    }

    class Program
    {
        delegate bool sort(int a, int b);

        delegate int del(int i);
        public static bool ByteToString(byte[] inputData, ref string outputData)
        {
            outputData = null;
            try
            {
                Encoding contryEnc = Encoding.GetEncoding("utf-8");
                outputData = contryEnc.GetString(inputData);

                int index = outputData.IndexOf('\0');
                if (index >= 0)
                {
                    outputData = outputData.Remove(index);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool cal(int a, int b)
        {
            return a > b;
        }
        public static string Get(string key, string alt = null, string def = null)
        {
            return "";
        }
        static void Main(string[] args)
        {
            string a2 = "\u2649";

            Console.WriteLine(a2);

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Get("", alt: "11");

            string x = "just a normal string";
            Console.WriteLine(\u0078);

            byte[] inputData = new byte[] { 0x11, 0x1, 0x12 };
            string aa="";
            ByteToString(inputData, ref aa);

            Console.WriteLine(aa);

            Func<int, int, bool> sort = (a1, b1) =>
            {
                return a1 > b1;
            };

            int[] items = new[] { 1, 4, 2, 11, 7 };
            var type = typeof(sort);
            Console.WriteLine("\n Base Class for ok Delegate type:\t" + type.BaseType);
            Console.WriteLine("\n Is Class : \t" + type.IsClass);
            Console.WriteLine("\n Is Sealed Class : \t" + type.IsSealed);

            SimpleSort<int>.BubbleSort(items, sort);

            Func<int, int, bool> sort1 = delegate (int a, int b) { return a - b > 0; };
            SimpleSort<int>.TestDelegate((Func<int, int, bool>)delegate (int a, int b) { return a - b > 0; });

            Func<int, int, bool>[] patterns =
            {
                (xx,y) => { return true; },
                (xx,y) => { return true; }
             };

            Console.ReadLine();
        }
    }
}
