using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBitWise
{
    class Program
    {
        public static void Main()
        {
            int[] tab = { 1, 2, 5, 2, 1 };
            Console.WriteLine(GetSingle(tab));

            Swap(ref tab[0], ref tab[1]);
            Console.WriteLine(tab[0] + " " + tab[1]);
            Swap(ref tab[0], ref tab[1]);

            Console.WriteLine(Mult(tab[1], tab[2]));
            Console.WriteLine(Add(tab[1], tab[2]));

            PrintPowerOfTwo();
        }

        private static int GetSingle(IEnumerable<int> tab)
        {
            var result = 0;
            foreach (var i in tab)
                result ^= i;
            return result;
        }

        private static void Swap(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }

        private static int Mult(int a, int b)
        {
            var c = 0;
            while (b != 0)
            {
                if ((b & 1) != 0)
                    c += a;
                a <<= 1;
                b >>= 1;
            }
            return c;
        }

        private static int Add(int a, int b)
        {
            while (a != 0)
            {
                var c = b & a;
                b ^= a;
                c <<= 1;
                a = c;
            }
            return b;
        }

        private static void PrintPowerOfTwo()
        {
            for (var i = 0; i < 9; i++)
                Console.Write((1 << i) + " ");
        }
    }
}
