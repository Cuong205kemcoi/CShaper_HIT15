using System;
using System.Collections.Generic;
using System.Text;

namespace HITBANK
{
    abstract class Account
    {
        protected string accountNumber;
        protected double balance;

        public Account(string accountNumber, double balance)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine("Gửi tiền thành công. Số dư hiện tại: " + balance);
            }
            else
            {
                Console.WriteLine("Số tiền gửi không hợp lệ.");
            }
        }

        public virtual bool  Withdraw(double amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine("Rút tiền thành công. Số dư còn lại: " + balance);
                return true;
            }
            else
            {
                Console.WriteLine("Số dư không đủ để rút.");
                return false;
            }
        }

        public double GetBalance()
        {
            return balance;
        }

        public string GetAccountNumber()
        {
            return accountNumber;
        }

        public abstract void PrintAccountInfo();
    }

    class SavingAccount : Account
    {
        private double interestRate;

        public SavingAccount(string accountNumber, double balance, double interestRate)
            : base(accountNumber, balance)
        {
            this.interestRate = interestRate;
        }

        public override void PrintAccountInfo()
        {
            Console.WriteLine("Tài khoản tiết kiệm - Số tài khoản: " + accountNumber);
            Console.WriteLine("Số dư: " + balance + ", Lãi suất: " + interestRate + "%");
        }
    }

    class CheckingAccount : Account
    {
        private SavingAccount linkedSavingAccount;

        public CheckingAccount(string accountNumber, double balance)
            : base(accountNumber, balance)
        {
        }

        public void LinkSavingAccount(SavingAccount savingAccount)
        {
            this.linkedSavingAccount = savingAccount;
        }

        public override bool Withdraw(double amount)
        {
            if (base.Withdraw(amount))
            {
                return true;
            }

            if (linkedSavingAccount != null)
            {
                double deficit = amount - balance;
                if (linkedSavingAccount.GetBalance() >= deficit)
                {
                    linkedSavingAccount.Withdraw(deficit);
                    balance = 0;
                    Console.WriteLine("Rút tiền thành công từ cả hai tài khoản.");
                    return true;
                }
            }

            Console.WriteLine("Rút tiền thất bại.");
            return false;
        }

        public override void PrintAccountInfo()
        {
            Console.WriteLine("Tài khoản vãng lai - Số tài khoản: " + accountNumber);
            Console.WriteLine("Số dư: " + balance);
        }
    }

    class Customer
    {
        private string name;
        private List<Account> accounts;

        public Customer(string name)
        {
            this.name = name;
            this.accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            if (accounts.Count < 4)
            {
                accounts.Add(account);
            }
            else
            {
                Console.WriteLine("Không thể thêm tài khoản, số tài khoản đã đạt tối đa.");
            }
        }

        public Account GetAccount(string accountNumber)
        {
            foreach (Account account in accounts)
            {
                if (account.GetAccountNumber() == accountNumber)
                {
                    return account;
                }
            }
            return null;
        }

        public void PrintAccountInfo()
        {
            Console.WriteLine("Khách hàng: " + name);
            foreach (Account account in accounts)
            {
                account.PrintAccountInfo();
            }
        }

        public double GetTotalBalance()
        {
            double total = 0;
            foreach (Account account in accounts)
            {
                total += account.GetBalance();
            }
            return total;
        }

        public string GetName()
        {
            return name;
        }
    }

    class Bank
    {
        private List<Customer> customers;

        public Bank()
        {
            this.customers = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public Customer FindCustomerByName(string name)
        {
            foreach (Customer customer in customers)
            {
                if (customer.GetName().Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return customer;
                }
            }
            return null;
        }

        public Account FindAccount(string accountNumber)
        {
            foreach (Customer customer in customers)
            {
                Account account = customer.GetAccount(accountNumber);
                if (account != null)
                {
                    return account;
                }
            }
            return null;
        }

        public void Deposit(string accountNumber, double amount)
        {
            Account account = FindAccount(accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Không tìm thấy tài khoản.");
            }
        }

        public void Withdraw(string accountNumber, double amount)
        {
            Account account = FindAccount(accountNumber);
            if (account != null)
            {
                account.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Không tìm thấy tài khoản.");
            }
        }

        public void PrintAllCustomers()
        {
            foreach (Customer customer in customers)
            {
                customer.PrintAccountInfo();
                Console.WriteLine("Tổng số tiền: " + customer.GetTotalBalance());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Bank bank = new Bank();
            Console.WriteLine("Họ Tên :");
            string name=Console.ReadLine();
            Console.WriteLine("Số tài khoản tiết kiệm:");
            string stk=Console.ReadLine();
            Console.WriteLine("Số dư tk tiết kiệm:");
            double sd = double.Parse(Console.ReadLine());
            Console.WriteLine("Lãi suất ngân hàng tiết kiệm :");
            double ls= double.Parse(Console.ReadLine());
            Console.WriteLine("Số tài khoản vãng lai :");
            string STK= Console.ReadLine();
            Console.WriteLine("Số dư của tk vãng lai :");
            double SD= double.Parse(Console.ReadLine());
            Customer customer1 = new Customer(name);
            SavingAccount savingAccount = new SavingAccount(stk, sd, ls);
            CheckingAccount checkingAccount = new CheckingAccount(STK, SD);
            checkingAccount.LinkSavingAccount(savingAccount);
            customer1.AddAccount(savingAccount);
            customer1.AddAccount(checkingAccount);

            bank.AddCustomer(customer1);
            string tk;
            do
            {
                Console.WriteLine("Số tài khoản muốn gửi tiền :");
                tk = Console.ReadLine();
            } while (tk != null || (tk != stk && tk != STK));
            double tien;
            do
            {
                Console.WriteLine("Số tiền muốn gửi :");
                tien = double.Parse(Console.ReadLine());
            } while (tien <=0);
            string TK;
            do {
                Console.WriteLine("Số tài khoản muốn rút tiền :");
                TK = Console.ReadLine();
            } while (TK != null || (TK != stk && TK != STK));
            double TIEN;
            do
            {
                Console.WriteLine("Số tiền muốn rút :");
                TIEN = double.Parse(Console.ReadLine());
            } while (TIEN <= 0 || TIEN > SD);
            bank.Deposit(tk, tien);
            bank.Withdraw(TK, TIEN);
            bank.PrintAllCustomers();
            Console.ReadKey();
        }
    }
}
