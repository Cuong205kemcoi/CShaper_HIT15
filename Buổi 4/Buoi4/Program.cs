using System;
using System.Text;

class SoDoDoDai
{
    public double A { get; set; }
    public double B { get; set; }

    public SoDoDoDai() { }

    public SoDoDoDai(double a, double b)
    {
        A = a;
        B = b;
    }
}

class HinhHoc
{
    public double A { get; set; }
    public double B { get; set; }

    public HinhHoc() { }

    public HinhHoc(double a, double b)
    {
        A = a;
        B = b;
    }

    public virtual double GetArea()
    {
        return 0;
    }
}

class TamGiac : HinhHoc
{
    public TamGiac(double a, double b) : base(a, b) { }

    public override double GetArea()
    {
        return A * B / 2;
    }
}

class HinhChuNhat : HinhHoc
{
    public HinhChuNhat(double a, double b) : base(a, b) { }

    public override double GetArea()
    {
        return A * B;
    }
}

namespace Buoi4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding =Encoding.UTF8;
            Console.WriteLine("Nhập số đo cho hình:");
            Console.Write("Nhập chiều dài (A): ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhập chiều rộng (B): ");
            double b = Convert.ToDouble(Console.ReadLine());

            // Tạo đối tượng TamGiac
            TamGiac tg = new TamGiac(a, b);
            Console.WriteLine($"Diện tích Tam Giác: {tg.GetArea()}");

            // Tạo đối tượng HinhChuNhat
            HinhChuNhat hcn = new HinhChuNhat(a, b);
            Console.WriteLine($"Diện tích Hình Chữ Nhật: {hcn.GetArea()}");

            Console.ReadLine();
        }
    }
}
