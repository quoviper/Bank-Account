namespace BankAccountApp.Tests
{
    [TestClass]
    public class WithdrawTest
    {
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
        public void WithdrawLimitExceed()
        {
            BankAccount account = new BankAccount("Daniil", 2000000);
            ArgumentException exception = Assert.Throws<ArgumentException>(() => account.Withdraw(1500000));
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
        public void WithdrawZeroAmount()
        {
            BankAccount account = new BankAccount("Daniil", 100);
            account.Withdraw(0);
            Assert.AreEqual(100, account.GetBalance());
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

        [TestMethod]
        public void WithdrawToZeroAmount()
        {
            BankAccount account = new BankAccount("Daniil", 100);
            account.Withdraw(100);
            Assert.AreEqual(0, account.GetBalance());
        }
    }
}
