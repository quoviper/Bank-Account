namespace BankAccountApp.Tests
{
    [TestClass]
    public class BankAccountTest
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
    }
}
