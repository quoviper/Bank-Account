namespace BankAccountApp.Tests
{
    [TestClass]
    public class DepositTest
    {
        [TestMethod]
        public void DepositValidAmount()
        {
            BankAccount account = new BankAccount("Daniil", 100);
            account.Deposit(50);
            Assert.AreEqual(150, account.GetBalance());
        }

        [TestMethod]
        public void DepositNegativeAmount()
        {
            BankAccount account = new BankAccount("Daniil", 100);
            ArgumentException exception = Assert.Throws<ArgumentException>(() => account.Deposit(-50));
        }

        [TestMethod]
        public void DepositLimitExceed()
        {
            BankAccount account = new BankAccount("Daniil", 0);
            ArgumentException exception = Assert.Throws<ArgumentException>(() => account.Deposit(2000000));
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
        public void DepositZeroAmount()
        {
            BankAccount account = new BankAccount("Daniil", 100);
            account.Deposit(0);
            Assert.AreEqual(100, account.GetBalance());
        }
        [TestMethod]
        public void DepositDecimalAmount()
        {
            BankAccount account = new BankAccount("Daniil", 100);
            account.Deposit(50.75m);
            Assert.AreEqual(150.75m, account.GetBalance());
        }
        [TestMethod]
        public void DepositMultipleTimes()
        {
            BankAccount account = new BankAccount("Daniil", 100);
            account.Deposit(50);
            account.Deposit(25);
            account.Deposit(10);
            Assert.AreEqual(185, account.GetBalance());
        }
        [TestMethod]
        public void DepositMaxThenMore()    
        {
            BankAccount account = new BankAccount("Daniil", 0);
            account.Deposit(1000000);
            account.Deposit(156000);
            Assert.AreEqual(1156000, account.GetBalance());
        }
    }
}
