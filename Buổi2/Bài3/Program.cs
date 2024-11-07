using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bài3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Dictionary<string, Dictionary<string, int>> dic = new Dictionary<string, Dictionary<string, int>>();
            int n;
            Console.Write("Nhập số lượng nhân viên :");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhập thông tin Nhân viên thứ " + (i + 1));
                Console.Write("Họ & Tên : ");
                string name = Console.ReadLine();
                Dictionary<string, int> nv = new Dictionary<string, int>();
                Console.Write("Tên sản phẩm : ");
                string od = Console.ReadLine();
                Console.Write("Số lượng đơn hàng :");
                int m = int.Parse(Console.ReadLine());
                nv.Add(od, m);
                dic.Add(name, nv);
            }
            //Tìm nhân viên bán được tổng số lượng sản phẩm nhiều nhất.
            int max = 0;
            string ST = "";
            string NV = "";
            foreach (var name in dic)
            {
                foreach (var sp in name.Value)
                {
                    if (max < sp.Value)
                    {
                        max = sp.Value;
                        ST = sp.Key;
                        NV = name.Key;
                    }
                }
            }
            Console.WriteLine($"Nhân viên bán đc tổng số lượng sản phẩm nhiều nhất là: {NV} | {ST} | {max}");
            Dictionary<string, int> sanpham = new Dictionary<string, int>();
            int S = 0;
            string Ten = "";

            // Duyệt qua từng nhân viên và cộng tổng các sản phẩm cùng tên
            foreach (var a in dic)
            {
                foreach (var i in a.Value)
                {
                    if (sanpham.ContainsKey(i.Key))
                    {
                        sanpham[i.Key] += i.Value;
                    }
                    else
                    {
                        sanpham[i.Key] = i.Value;
                    }
                    // Sử dụng Math.Max để tìm sản phẩm có tổng số lượng cao nhất
                    S = Math.Max(S, sanpham[i.Key]);
                    if (S == sanpham[i.Key])
                    {
                        Ten = i.Key;
                    }
                }
            }
            Console.WriteLine($"Sản phẩm bán chạy nhất là : {Ten}  |  {S}");
            Console.ReadLine();
        }
    }
}
