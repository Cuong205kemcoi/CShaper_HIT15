using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace b4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Nhập Thông Tin Giao Dịch");
            Console.WriteLine(new string('=',60));
            Console.WriteLine("Bên A");
            Console.WriteLine(new string('=', 30));
            Program pro=new Program();
            Console.Write("\nChủ tài khoản:");
            string name1 = Console.ReadLine();
            Console.Write("\nSố tài khoản :");
            long id1 = long.Parse(Console.ReadLine());
            Console.Write("\nSố dư hiện tại:");
            double money1 = double.Parse(Console.ReadLine());
            Account account = new Account(id1, name1, money1);
            Console.WriteLine("Bên B");
            Console.WriteLine(new string('=', 30));
            Console.Write("\nChủ tài khoản:");
            string name2 = Console.ReadLine();
            Console.Write("\nSố tài khoản :");
            long id2 = long.Parse(Console.ReadLine());
            Console.Write("\nSố dư hiện tại:");
            double money2 = double.Parse(Console.ReadLine());
            Console.Write("thời gian");
            int Vao=int.Parse(Console.ReadLine());
            int ra=int.Parse(Console.ReadLine());
            int solandaohan = (int)(ra / Vao);

        }
        
    }
}
class Account
{
    public long ID_acc { get; set; }
    public string Name { get; set; }
    public double money {  get; set; }
    private const double laiXuat = 0.035;
    public string ToString()
    {
        return string.Format("{0,-20}|{1,-25}|{2,-14}.vnd",ID_acc,Name,money);
    }
    public Account() { }
    public Account(long iD_acc, string name, double money)
    {
        ID_acc = iD_acc;
        Name = name;
        this.money = money;
    }
    public Account(long iD_acc, string name)
    {
        ID_acc = iD_acc;
        Name = name;
        money = 50;
    }
    public double NapTien(Account user1,double TienNap)
    {
        money = TienNap + money;
        return money;
    }
    public double RutTien(Account user2,double Ruttien)
    {
        if (money > 0)
        {
            Console.WriteLine("Rút tiền thành công ");
            Console.WriteLine("Số dư hiện tại :");
            money = Ruttien - money;
            return money;
        }
        else
        {
            Console.WriteLine("Số dư không đủ thể thực hiện giao dịch!");
            Console.WriteLine("Số dư hiện tại :");
            return money;
        }
    }
    public double Money(Account user,double tien)
    {
        return tien;
    }
    public double DaoHan(Account user,int solandaohan)
    {
        return money*Math.Pow((laiXuat+1),solandaohan);
    }
    public string ChuyenKhoan(Account user1, Account user2,double tien1,double tien2,double Ruttien,double TienNap)
    {
        string ck = string.Format("{0,-20}||{2,-20}\n{3,-45}||{4,-45}\n{5,-45}{6,-45}",user2,user1,Money(user1,tien1),Money(user2,tien2),RutTien(user2,Ruttien),NapTien(user1,TienNap));
        return ck;   
    }
}
