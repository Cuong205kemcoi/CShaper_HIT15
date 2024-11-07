namespace Baitap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 20; i += 2)
            {
                Console.Write(i + " ");
            }
            int j = 1;
            int s = 0;
            while (j <= 100)
            {
                s += j;
                j += 1;
            }
            Console.WriteLine("Sum =" + s);
            String N;
            do
            {
                Console.Write("Nhap N >0 =");
                N = Console.ReadLine();
            } while (int.Parse(N) <= 0);
            int count = 1;
        st:
            Console.WriteLine(count);
            count++;
            if (count <= 10)
            {
                goto st;
            }
        }
    }
}
