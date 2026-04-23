namespace BankAccountApp.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void ConstructorValidData()
        {
            BankAccount account = new BankAccount("Daniil", 500);
            Assert.AreEqual("Daniil", account.GetOwnerName());
            Assert.AreEqual(500, account.GetBalance());
        }

        [TestMethod]
        public void ConstructorNegativeBalance()
        {
            BankAccount account = new BankAccount("Dan", -100);
            Assert.AreEqual(-100, account.GetBalance());
        }

        [TestMethod]
        public void ConstructorDecimalBalance()
        {
            BankAccount account = new BankAccount("Dan", 1000.001m);
            Assert.AreEqual(1000.001m, account.GetBalance());
        }
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

        [TestMethod]
        public void WithdrawValidAmount()
        {
            BankAccount account = new BankAccount("Daniil", 100);
            account.Withdraw(50);
            Assert.AreEqual(50, account.GetBalance());
        }

        [TestMethod]
        public void WithdrawNegativeAmount()
        {
            BankAccount account = new BankAccount("Daniil", 100);
            ArgumentException exception = Assert.Throws<ArgumentException>(() => account.Withdraw(-150));
        }

        [TestMethod]
        public void WithdrawDecimalAmount()
        {
            BankAccount account = new BankAccount("Daniil", 100);
            account.Withdraw(50.75m);
            Assert.AreEqual(49.25m, account.GetBalance());
        }

        [TestMethod]
        public void WithdrawMultipleTimes()
        {
            BankAccount account = new BankAccount("Daniil", 100);
            account.Withdraw(50);
            account.Withdraw(25);
            account.Withdraw(10);
            Assert.AreEqual(15, account.GetBalance());
        }

        [TestMethod]
        public void WithdrawMaxThenMore()
        {
            BankAccount account = new BankAccount("Daniil", 2000000);
            account.Withdraw(1000000);
            account.Withdraw(500000);
            Assert.AreEqual(500000, account.GetBalance());
        }

        [TestMethod]
        public void WithdrawMoreThanBalance()
        {
            BankAccount account = new BankAccount("Daniil", 100);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => account.Withdraw(150));
        }
    }
}
