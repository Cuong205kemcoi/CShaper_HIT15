using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDic
{
    internal class Program
    {
        static Dictionary<string,Dictionary<string, int>> dict()
        {
            return new Dictionary<string, Dictionary<string, int>>() ;
        }
        static void Ip(){
            var  input =dict();
            foreach (var i in input)
            {
                foreach (var k in i.Value)
                {
                    Console.WriteLine($"Nhan vien : {i.Key} San pham :{k.Key} So luong : {k.Value}");
                }
            }
        }
        static void Main(string[] args)
        {
            int n;
            var dic=dict();
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập số nhân viên = ");
            n=int.Parse(Console.ReadLine());
            while (n <= 0)
            {
                Console.Write("Nhập số nhân viên >0 = ");
                n = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++) 
            {
                string name;
                string sanpham;
                int sl;
                Dictionary<string , int> nv = new Dictionary<string , int>();
                Console.WriteLine("Nhập thông tin nhân viên thứ "+(i+1));
                Console.Write("Họ và Tên :");
                name= Console.ReadLine();
                Console.Write("Sản phẩm : ");
                sanpham= Console.ReadLine();
                Console.Write("Số lượng :");
                sl=int.Parse(Console.ReadLine());
                nv.Add(sanpham, sl);
                dic.Add(name, nv);
            }
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Thông tin nhân viên sau khi nhập ");
            foreach (var i in dic)
            {
                foreach(var k in i.Value)
                {
                    Console.WriteLine($"{i.Key} || {k.Key} || {k.Value}");
                }
            }
            Dictionary<string, int> sp = new Dictionary<string, int>();
            //tìm nhân viên có số lượng sản phảm bán nhiều nhất
            int Maxsp = 0;
            string maxNameNV = "";
            foreach (var k in dic)
            {
                int s = 0;
                foreach( var v in k.Value)
                {
                    s += v.Value;
                }
                if(Maxsp < s)
                {
                    Maxsp = s;
                    maxNameNV=k.Key;
                }
            }
            Console.WriteLine($"Nhân viên có số lượng sản phẩm nhiều nhất là :{maxNameNV} - {Maxsp} ");


            int MaxSum = 0;
            string MaxNameSP = "";
            //tính tổng số lượng từng sẩn phẩm
            foreach (var i in dic)
            {
                foreach (var k in i.Value)
                {
                    if (sp.ContainsKey(k.Key))
                    {
                        sp[k.Key] += k.Value;
                    }
                    else
                    {
                        sp[k.Key]= k.Value;
                    }
                }
            }
            foreach(var k in sp)
            {
                if (k.Value > MaxSum)
                {
                    MaxSum = k.Value;
                    MaxNameSP = k.Key;
                }
            }
            Console.WriteLine($"Sản phẩm bán đc nhiều nhất là : {MaxNameSP} với lượt bán {MaxSum}");
            Console.ReadLine();
        }
    }
}
