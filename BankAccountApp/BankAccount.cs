using BankAccountApp;
using System;
using System.Collections.Generic;

public class BankAccount
{
    private string ownerName;
    private decimal balance;
    private const decimal maxAmount = 1000000;
    private readonly List<OperationRecord> operationRecords;
    public BankAccount(string ownerName, decimal initialBalance)
    {
        this.ownerName = ownerName;
        this.balance = initialBalance;
        this.operationRecords = new List<OperationRecord>();
        operationRecords.Add(new OperationRecord() {Type = "Создание счёта", Amount = initialBalance, DateTime = DateTime.Now});
    }

    public IReadOnlyList<OperationRecord> GetOperationRecords() => operationRecords.AsReadOnly();
    public void ClearHistory() => operationRecords.Clear();
    public string GetOwnerName() => ownerName;
    public decimal GetBalance() => balance;
    public void Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Сумма пополнения не может быть отрицательной.");
        }
        if (amount > maxAmount)
        {
            throw new ArgumentException($"Сумма пополнения не может превышать {maxAmount}.");
        }
        balance += amount;
        operationRecords.Add(new OperationRecord() {Type = "Пополнение", Amount = amount, DateTime = DateTime.Now});
    }
    public void Withdraw(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Сумма снятия не может быть отрицательной.");
        }
        if (amount > maxAmount)
        {
            throw new ArgumentException($"Сумма снятия не может превышать {maxAmount}.");
        }
        if (amount > balance)
        {
            throw new InvalidOperationException("Недостаточно средств на счёте.");
        }
        balance -= amount;
        operationRecords.Add(new OperationRecord() {Type = "Снятие", Amount = amount, DateTime = DateTime.Now});
    }
}
