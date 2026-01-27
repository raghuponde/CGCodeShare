
record record_name(data_type Property1, data_type Property2, …);

-- would be compiled as:

Compiled code of Record

class record_name
{
   public data_type Property1 { get; init; }
   public data_type Property2 { get; init; }
 
   public record_name(data_type Parameter1, data_type Parameter2)
   {
      this.Property1 = Parameter1;
      this.Property2 = Parameter2;
   }
}


Features:

Records are 'immutable' by default.

All the record members become as 'init-only' properties.

Records can also be partially / fully mutable - by adding mutable properties.

Supports value-based equality.

Supports inheritance.

Supports non-destructive mutation using 'with' expression.

  namespace RecordDemo
{

    public record Person(string Name,int Age);
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("John", 20);
            Person p2 = new Person("Scott", 34);
            Console.WriteLine($"{p1.Name}--{p1.Age}");
            Console.WriteLine($"{p2.Name}--{p2.Age}");
//            p1.Name="David"//error
     // only in constructor u can set the values 

            Console.ReadLine();
        }
    }
}

5)Expression bodied methods 
***************************
using System;

namespace ExpressionBodiedDemo
{
    public class BankAccount
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }
        public string AccountHolder { get; set; }

        // Traditional Constructor
        public BankAccount(string accountNumber, string accountHolder, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = initialBalance >= 0 ? initialBalance : 0;
        }

        // Traditional Destructor/Finalizer
        ~BankAccount()
        {
            Console.WriteLine($"Account {AccountNumber} finalized - logging closure");
        }

        // Traditional Methods
        public bool Deposit(decimal amount) 
        {
            if (amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public string GetAccountStatus()
        {
            return Balance > 1000 ? "Premium" : "Standard";
        }

        public decimal CalculateInterestRate()
        {
            return Balance switch
            {
                > 10000 => 0.05m,
                > 5000 => 0.04m,
                _ => 0.02m
            };
        }

        // Traditional Property
        public string Summary => $"Account: {AccountNumber}, Balance: ${Balance:N2}";
    }

    class Program
    {
        static void Main()
        {
            var account = new BankAccount("ACC123", "John Doe", 5000);
            account.Deposit(2500);
            Console.WriteLine(account.Summary);
            Console.WriteLine($"Status: {account.GetAccountStatus()}");
        }
    }
}

Converting into Expression Bodied way 
----------------------------------------
namespace ExpressionBodiedMethodsDemo
{
    public class BankAccount
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }
        public string AccountHolder { get; set; }

        // Traditional Constructor
        public BankAccount(string accountNumber, string accountHolder, decimal initialBalance)
            => (AccountNumber, AccountHolder, Balance) =
            (accountNumber, accountHolder, initialBalance >= 0 ? initialBalance : 0);

        // Traditional Destructor/Finalizer
        ~BankAccount() => Console.WriteLine($"Account {AccountNumber} finalized - logging closure");

        // Traditional Methods
        public bool Deposit(decimal amount) => (amount > 0) && (Balance+=amount)>0 ? true : false;
        
        public bool Withdraw(decimal amount)=>(amount>0) && (Balance-=amount)>0? true : false;


        public string GetAccountStatus() => Balance > 1000 ? "Premimum" : "Standard";
      
        //public decimal CalculateInterestRate()
        //{
        //    return Balance switch
        //    {
        //        > 10000 => 0.05m,
        //        > 5000 => 0.04m,
        //        _ => 0.02m
        //    };
        //}

        // Traditional Property
        public string Summary => $"Account: {AccountNumber}, Balance: ${Balance:N2}";
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("ACC123", "John Doe", 5000);
            account.Deposit(2500);
            Console.WriteLine(account.Summary);
            Console.WriteLine($"Status: {account.GetAccountStatus()}");
            Console.ReadLine();
        }
    }
}


