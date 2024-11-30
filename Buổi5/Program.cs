using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Hãy viết lớp HinhChuNhat gồm có:
// Attributes: chiều dài, chiều rộng.
// Phương thức thiết lập (set), và lấy (get) thông tin chiều dài, chiều rộng.
// Phương thức tính diện tích, chu vi.
// Phương thức toString gồm các thông tin dài, rộng, diện tích, chu vi.
//- Xây dựng lớp chứa hàm main cho phần kiểm nghiệm. Dài rộng có thể nhập từ bàn phím.

class HCN
{
    private double a;
    private double b;
    public HCN() { }

    public double getA() { return a; }
    public double getB() { return b; }
    public void setA(double a) {
        this.a = a; }
    public void setB(double b)
    {
        this.b = b;
    }
    public double DT(double a,double b)
    {
        return a * b;
    }
    public double CV(double a,double b)
    {
        return (a + b) * 2;
    }
    public void toString(double a, double b) {
        Console.WriteLine($"CV={CV(a,b)},DT={DT(a,b)}");
    }
}

namespace Buổi5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding=System.Text.Encoding.UTF8;
            HCN hcn = new HCN();
            Console.Write("A=");
            double a= double.Parse(Console.ReadLine());
            Console.Write("B=");
            double b= double.Parse(Console.ReadLine());
            hcn.setA(a);
            hcn.setB(b);
            hcn.toString(a,b);
            Console.ReadKey();
        }
    }
}
