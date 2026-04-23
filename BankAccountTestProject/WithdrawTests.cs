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
