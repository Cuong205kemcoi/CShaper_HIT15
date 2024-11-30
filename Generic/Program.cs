using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Learn
{
    internal class Program
    {
        public delegate int MyDelegeate(int x, int y);
        public static int Sum(int x, int y)
        {
            return x + y;
        }
        public static void Main(string[] args)
        {
            MyDelegeate del1 = new MyDelegeate(Sum);
            Console.WriteLine(del1(1,2));
            Console.ReadKey();
        }
    }

}

