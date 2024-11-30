using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Employee
{
    protected string name { get; set; }
    protected int paymentPerHour { get; set; }

    public Employee() { }
    public Employee(string name, int paymentPerHour) 
    {
        this.name = name;
        this.paymentPerHour = paymentPerHour;
    } 
    public int getPaymentPerHour() { return paymentPerHour; }
    public string getName() { return name; }
    public void setName(string name)
    {
        this.name += name;
    }
    public void setPaymentPerHour(int paymentPerHour)
    {
        this.paymentPerHour += paymentPerHour;
    }
}
