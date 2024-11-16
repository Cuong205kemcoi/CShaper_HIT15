using System;
using System.Text;

public class Time
{
    protected int Day;
    protected int Month;
    protected int Year;

    // Constructor mặc định
    public Time() { }

    // Constructor có tham số
    public Time(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    // Phương thức hiển thị ngày tháng năm
    public String DisplayTime()
    {
        return String.Format("{0,-5}{1,-5}{2,-5}", Day, Month, Year);
    }
}

public class People : Time
{
    public string Name;    // Sử dụng string thay vì mảng char
    public byte Age;
    public Time tg;
    public string Gender;  // Sử dụng string thay vì mảng char

    // Constructor mặc định
    public People() { }

    // Constructor có tham số
    public People(string name, byte age, Time TG, string gender)
    {
        Name = name;
        Age = age;
        tg = TG;
        Gender = gender;
    }

    // Phương thức hiển thị thông tin cá nhân
    public void DisplayInfo()
    {
        String xuat = String.Format("{0,-30}{1,-10}{2,-15}{3,-10}", Name, Age, tg.DisplayTime(), Gender);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Date:");

        Console.Write("\nNgày:");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("\nTháng:");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.Write("\nNăm:");
        int c = Convert.ToInt32(Console.ReadLine());

        Time myTime = new Time(a, b, c);


        Console.Write("\nTên:");
        string name = Convert.ToString(Console.ReadLine());
        Console.Write("\nTuổi:");
        byte age = Convert.ToByte(Console.ReadLine());

        Console.Write("\nGiới tính:");
        String gt = Convert.ToString(Console.ReadLine());
        int Day = Convert.ToInt32(Console.ReadLine());
        int Month = Convert.ToInt32(Console.ReadLine());
        int Year = Convert.ToInt32(Console.ReadLine());
        Time ns = new Time(Day, Month, Year);
        People person = new People(name, age, ns, gt);
        Console.WriteLine("THONG TIN CA NHAN ");
        Console.WriteLine(String.Format("{0,-30}{1,-10}{2,-15}{3,-10}", "Tên", "Tuổi", "Năm Sinh", "Giới tính"));
        person.DisplayInfo();
        Console.ReadLine();
    }
}
