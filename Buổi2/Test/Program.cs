namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Nhập số cần tìm :");
            a=int.Parse(Console.ReadLine());
            int k = a % 3;
            switch (k)
            { 
                case 0: 
                    Console.WriteLine("So {0} la so chia het cho 3",a);
                    break;
                default:
                    Console.WriteLine("So {0} không chia hết cho 3 ", a);

                    break;
            }
            Console.ReadKey();
        }
    }
}

