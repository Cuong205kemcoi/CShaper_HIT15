using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

//- Viết lớp Sinh viên như sau:
//Attributes(private):
// Mã sinh viên là số nguyên.
// Họ tên: chuỗi ký tự.
// Điểm LT, điểm TH : float
class SinhVien
{
    public int codeName {  get; set; }
    public string Name { get; set; }
    public float LT { get; set; }
    public float TH { get; set; }
    public SinhVien() { 
        codeName = 0;
        Name = "";
        LT = 0;
        TH = 0;
    }
    public SinhVien(int codeName, string name, float lT, float tH)
    {
        this.codeName = codeName;
        Name = name;
        LT = lT;
        TH = tH;
    }
    public float TBC()
    {
        return (LT + TH) / 2;
    }
    public string ToString()
    {
        return string.Format("{0,-10}{1,-25}{2,-5}{3,-5}{4,-5}",codeName,Name,LT,TH,TBC());
    }
}


namespace B2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n=int.Parse(Console.ReadLine());

            List<SinhVien> list = new List<SinhVien>(n);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"SV Thứ {(i+1)} :");
                Console.Write("ID :");
                int ID =int.Parse(Console.ReadLine());
                Console.Write("Name:");
                string Name=Console.ReadLine();
                Console.Write("LT= ");
                float LT =float.Parse(Console.ReadLine());
                Console.WriteLine("TH =");
                float TH =float.Parse(Console.ReadLine());
                SinhVien sv = new SinhVien(ID,Name,LT,TH);
                list.Add(sv);

            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(list[i].ToString());
            }
            Console.ReadKey();
        }
    }
}
