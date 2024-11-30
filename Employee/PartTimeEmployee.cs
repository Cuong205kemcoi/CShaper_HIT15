using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ParttimeEmployee : Employee
{
    public int workingHour;
    public ParttimeEmployee() { }
    public ParttimeEmployee(string name, int paymentPerHour, int workingHour)
    {
        this.name = name;
        this.paymentPerHour = paymentPerHour;
        this.workingHour = workingHour;
    }

}