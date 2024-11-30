using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
class Vehicle
{
    public String loaiXe {  get; set; }
    public int dungTich {  get; set; }
    public int GiaTri {  get; set; }
    public Vehicle() { }
    public Vehicle(string loaiXe, int dungTich, int giaTri)
    {
        this.loaiXe = loaiXe;
        this.dungTich = dungTich;
        GiaTri = giaTri;
    }
    public double Thue()
    {
        if (dungTich < 100)
        {
            return GiaTri*0.01;
        }
        else if (dungTich <= 200)
        {
            return GiaTri * 0.03;
        }
        else
        {
            return  GiaTri*0.05;
        }
    }

    public string ToString()
    {
        return string.Format("{0,-30}{1,-10}{2,-10}{3,-10}",loaiXe,dungTich, GiaTri,Thue());
    }
}
namespace bai3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n;
            do
            {
                System.Console.Write("Nhập số lượng người dùng :");
                n = int.Parse(System.Console.ReadLine());
            } while (n <= 0);
            List<string>strings = new List<string>();
            List<string>Name= new List<string>();
            for (int i = 0; i < n; i++)
            {

                Console.WriteLine($"Nhập  thông tin người dùng thứ {(i + 1)}");
                Console.Write("Chủ Sở Hữu: ");
                string name = Console.ReadLine();
                Console.Write("Loại xe:");
                string lx = Console.ReadLine();
                Console.Write("Dung Tích :");
                int DT = int.Parse(Console.ReadLine());
                Console.Write("Trị Giá Xe:");
                int GT = int.Parse(Console.ReadLine());
                Vehicle vh = new Vehicle(lx, DT, GT);
                string tostring=vh.ToString();
                Name.Add(name);
                strings.Add(tostring);
            }
            Console.WriteLine("{0,-30}{1,-30}{2,-10}{3,-10}{4,-10}", "Chủ Sở Hữu", "Loại Xe", "Dung Tích", "Giá Trị", "Thuế ");
            Console.WriteLine(new string('=', 90));
            for (int i = 0; i < n; i++) 
            {
                Console.WriteLine(string.Format("{0,-30}{1,-60}", Name[i], strings[i]));
            }
            Console.ReadKey();
        }
    }
}
