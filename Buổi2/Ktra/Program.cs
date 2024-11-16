using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ktra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int k;
        
            k = int.Parse(Console.ReadLine());
   
            for (int I = 0; I < k; I++)
            {
                int n;
               
                
                n = int.Parse(Console.ReadLine());
             
                string[] ar = Console.ReadLine().Split(' ');

                int[] a = new int[n];

                for (int i = 0; i < ar.Length; i++)
                {
                    a[i] = int.Parse(ar[i]);
                }
                int kt = 0;
                for (int i = 0; i < ar.Length - 1; i++)
                {
                    if (Math.Abs(Convert.ToInt32(ar[i + 1]) - Convert.ToInt32(ar[i])) != 5 &&
                        Math.Abs(Convert.ToInt32(ar[i + 1]) - Convert.ToInt32(ar[i])) != 7)
                    {
                        kt = 1;                        
                    }
                }
                if(kt == 0)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
            
        }
    }
}
