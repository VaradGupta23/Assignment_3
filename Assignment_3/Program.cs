using System;
using System.Runtime.InteropServices;

namespace Assignment_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            company.CreateAndDisplayEmployee();

            BankAccount account = new BankAccount("123456789", "Alice Johnson", 5000m);
            account.Deposit(1500m);
            account.Withdraw(2000m);
            account.DisplayAccountDetails();

            int[] numbers = { 10, 20, 30, 40, 50 };
            double average = MathHelper.CalculateAverage(numbers);
            Console.WriteLine($"The average is: {average}");

            Logger.LogMessage("This is a log message from the Logger class.");

            Shape circle = new Circle(5);
            Console.WriteLine($"Area of Circle: {circle.CalculateArea():F2}");

            Shape rectangle = new Rectangle(10, 5);
            Console.WriteLine($"Area of Rectangle: {rectangle.CalculateArea():F2}");

            Vehicle vehicle = new Vehicle();
            vehicle.StartEngine();
            vehicle.StopEngine();

            Car car = new Car();
            car.StartEngine();
            car.Drive();
            car.StopEngine();

            // Attempt to inherit from sealed class Car (will cause compile error if uncommented)
            // SportsCar sportsCar = new SportsCar();

            // Demonstrate BankAccount and SavingsAccount
            Bank_Account accounts = new Bank_Account("12345", 1000m);
            accounts.Deposits(200m);
            accounts.With_draw(100m);

            SavingsAccounts savingsAccount = new SavingsAccounts("67890", 1500m, 5m);
            savingsAccount.Deposits(300m);
            savingsAccount.ApplyInterest();
            savingsAccount.With_draw(200m);
        }
    }
}



class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
    public decimal Salary { get; set; }


    public Employee(string name, int age, decimal salary)
    {
        Name = name;
        Age = age;
        Salary = salary;
    }


    public void DisplayEmployeeDetails()
    {
        Console.WriteLine("Employee Details:");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Salary: {Salary:C}");
    }
}


class Company
{
    public void CreateAndDisplayEmployee()
    {

        Employee employee = new Employee("John Doe", 30, 60000m);


        employee.DisplayEmployeeDetails();
    }
}

class BankAccount
{
    public string AccountNumber { get; set; }
    public string AccountHolderName { get; set; }
    public decimal Balance { get; private set; }


    public BankAccount(string accountNumber, string accountHolderName, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        AccountHolderName = accountHolderName;
        Balance = initialBalance;
    }


    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount:C} successfully.");
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive.");
        }
    }


    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrew {amount:C} successfully.");
        }
        else
        {
            Console.WriteLine("Insufficient balance or invalid withdrawal amount.");
        }
    }

    public void DisplayAccountDetails()
    {
        Console.WriteLine("\nAccount Details:");
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Account Holder: {AccountHolderName}");
        Console.WriteLine($"Balance: {Balance:C}");
    }
}
static class MathHelper
{
    public static double CalculateAverage(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            return 0;

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        return (double)sum / numbers.Length;
    }
}


static class Logger
{
    public static void LogMessage(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}

public partial class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public abstract class Shape
{
    public abstract double CalculateArea();
}
public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}


public class Rectangle : Shape
{
    public double Length { get; set; }
    public double Width { get; set; }

    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public override double CalculateArea()
    {
        return Length * Width;
    }
}

public class Vehicle
{
    public void StartEngine()
    {
        Console.WriteLine("Engine started.");
    }

    public void StopEngine()
    {
        Console.WriteLine("Engine stopped.");
    }
}


public sealed class Car : Vehicle
{
    public void Drive()
    {
        Console.WriteLine("Car is driving.");
    }
}

public class Bank_Account
{
    public string Account_Number { get; set; }
    public decimal Balances { get; set; }

    public Bank_Account(string accountNumber, decimal initialBalance)
    {
        Account_Number = accountNumber;
        Balances = initialBalance;
    }

    public virtual void Deposits(decimal amount)
    {
        Balances += amount;
        Console.WriteLine($"Deposited {amount:C} to account {Account_Number}. New balance: {Balances:C}");
    }

    public virtual void With_draw(decimal amount)
    {
        if (amount <= Balances)
        {
            Balances -= amount;
            Console.WriteLine($"Withdrew {amount:C} from account {Account_Number}. New balance: {Balances:C}");
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }
    }
}


public sealed class SavingsAccounts : Bank_Account
{
    public decimal InterestRate { get; set; }

    public SavingsAccounts(string accountNumber, decimal initialBalance, decimal interestRate)
        : base(accountNumber, initialBalance)
    {
        InterestRate = interestRate;
    }


    public void ApplyInterest()
    {
        var interest = Balances * InterestRate / 100;
        Balances += interest;
        Console.WriteLine($"Applied {interest:C} interest to account {Account_Number}. New balance: {Balances:C}");
    }
}






