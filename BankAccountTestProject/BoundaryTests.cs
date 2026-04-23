namespace BankAccountApp.Tests
{
    [TestClass]
    public class BoundaryTests
    {
        [TestMethod]
        public void DepositLimitExceed()
        {
            BankAccount account = new BankAccount("Daniil", 0);
            ArgumentException exception = Assert.Throws<ArgumentException>(() => account.Deposit(2000000));
        }

        [TestMethod]
        public void DepositZeroAmount()
        {
            BankAccount account = new BankAccount("Daniil", 100);
            account.Deposit(0);
            Assert.AreEqual(100, account.GetBalance());
        }

        [TestMethod]
        public void DepositMaxBoundaryAmount()
        {
            BankAccount account = new BankAccount("Daniil", 0);
            account.Deposit(1000000);
            Assert.AreEqual(1000000, account.GetBalance());
        }

        [TestMethod]
        public void DepositMaxPlusOneBoundaryAmount()
        {
            BankAccount account = new BankAccount("Daniil", 0);
            ArgumentException exception = Assert.Throws<ArgumentException>(() => account.Deposit(1000001));
        }

        [TestMethod]
        public void WithdrawLimitExceed()
        {
            BankAccount account = new BankAccount("Daniil", 2000000);
            ArgumentException exception = Assert.Throws<ArgumentException>(() => account.Withdraw(1500000));
        }

        [TestMethod]
        public void WithdrawZeroAmount()
        {
            BankAccount account = new BankAccount("Daniil", 100);
            account.Withdraw(0);
            Assert.AreEqual(100, account.GetBalance());
        }

        [TestMethod]
        public void WithdrawToZeroAmount()
        {
            BankAccount account = new BankAccount("Daniil", 100);
            account.Withdraw(100);
            Assert.AreEqual(0, account.GetBalance());
        }

        [TestMethod]
        public void WithdrawMaxBoundaryAmount()
        {
            BankAccount account = new BankAccount("Daniil", 1000001);
            account.Withdraw(1000000);
            Assert.AreEqual(1, account.GetBalance());
        }

        [TestMethod]
        public void WithdrawMaxPlusOneBoundaryAmount()
        {
            BankAccount account = new BankAccount("Daniil", 1000002);
            ArgumentException exception = Assert.Throws<ArgumentException>(() => account.Withdraw(1000001));
        }
    }
}
