using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDelegate
{
    class Program
    {
        // reading
        // http://stackoverflow.com/q/2896715/1248177
        // http://stackoverflow.com/q/4233536/1248177

        delegate int Calcul(int i1, int i2);

        static int Add(int i, int j) { return i + j; }
        static int Sub(int i, int j) { return i - j; }
        static int Mul(int i, int j) { return i * j; }
        static int Div(int i, int j) { return i / j; }
        static int Mod(int i, int j) { return i % j; }

        static readonly Dictionary<char, Delegate> bistro = new Dictionary<char, Delegate>()
        {
            {'+', new Calcul(Add) },
            {'-', new Calcul(Sub) },
            {'*', new Calcul(Mul) },
            {'/', new Calcul(Div) },
            {'%', new Calcul(Mod) }
        };

        static void Main(string[] args)
        {
            Display(Add, 5, 1);
            Console.WriteLine("{0} {1} {2} = {3}", 2, bistro['+'].Method.Name, 2, bistro['+'].DynamicInvoke(2, 2));
            
            Random rand = new Random();
            foreach (char operand in "+-*/*-%+-*")
            {
                Delegate calcul = bistro[operand];
                int i = rand.Next(1, 10);
                int j = rand.Next(1, 10);
                Display((Calcul)calcul, i, j);
            }
            Console.ReadLine();
        }

        static void Display(Calcul calcul, int i, int j)
        {
            Console.WriteLine("{0} {1} {2} = {3}", i, calcul.Method.Name, j, calcul(i, j));
        }
    }
}
