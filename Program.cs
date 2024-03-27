using System;

public enum AccountType
{
    Checking,
    Savings
}

public class BankAccount
{
    // Properties
    public int AccountNumber { get; }
    public decimal Balance { get; private set; }
    public AccountType Type { get; }

    // Constructors
    public BankAccount(int accountNumber) : this(accountNumber, 0, AccountType.Checking)
    {
    }

    public BankAccount(int accountNumber, decimal initialBalance) : this(accountNumber, initialBalance, AccountType.Checking)
    {
    }

    public BankAccount(int accountNumber, decimal initialBalance, AccountType type)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
        Type = type;
    }

    // Methods
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive.");
        }

        if (Balance < amount)
        {
            throw new InvalidOperationException("Insufficient funds.");
        }

        Balance -= amount;
    }

    // Overloaded methods
    // Overload deposit method to accept an additional parameter for a description
    public void Deposit(decimal amount, string description)
    {
        Deposit(amount);
        Console.WriteLine($"Deposited {amount:C} - {description}");
    }

    // Overload withdraw method to accept an additional parameter for a description
    public void Withdraw(decimal amount, string description)
    {
        Withdraw(amount);
        Console.WriteLine($"Withdrawn {amount:C} - {description}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating different types of bank accounts using different constructors
        BankAccount checkingAccount = new BankAccount(123456789);
        BankAccount savingsAccount = new BankAccount(987654321, 1000m, AccountType.Savings);

        // Depositing and withdrawing money
        checkingAccount.Deposit(500);
        savingsAccount.Withdraw(200);

        // Using overloaded methods with descriptions
        checkingAccount.Deposit(100, "Birthday gift");
        savingsAccount.Withdraw(50, "Emergency expense");

        // Displaying balances
        Console.WriteLine($"Checking Account Balance: {checkingAccount.Balance:C}");
        Console.WriteLine($"Savings Account Balance: {savingsAccount.Balance:C}");
    }
}
