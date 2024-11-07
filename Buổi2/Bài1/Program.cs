namespace Bài1
{
    internal class Bài1
    {
        static void Main(string[] args)
        {
            int A, B;
            do
            {
                Console.Write("Nhap chieu dai :");
                A = int.Parse(Console.ReadLine());
            } while (A <= 0);
            do
            {
                Console.Write("Nhap chieu rong :");
                B = int.Parse(Console.ReadLine());
            } while (B <= 0);
            for (int i = 0; i < B; i++)
            {
                for (int j = 0; j < A; j++)
                {
                    if (i == 0 || i == B - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        if (j == 0 || j == A - 1)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
