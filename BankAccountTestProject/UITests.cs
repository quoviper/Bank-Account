using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using BankAccountApp;

namespace BankAccountApp.Tests
{
    [TestClass]
    public class UITests
    {
        private BankAccountForm form;

        [TestInitialize]
        public void SetUp()
        {
            form = new BankAccountForm();
            form.Show();
        }

        [TestMethod]
        public void NameIsVisibleAndEnabled()
        {
            Assert.IsTrue(form.nameTextBox.Visible);
            Assert.IsTrue(form.nameTextBox.Enabled);
        }

        [TestMethod]
        public void AmountIsVisibleAndEnabled()
        {
            Assert.IsTrue(form.amountTextBox.Visible);
            Assert.IsTrue(form.amountTextBox.Enabled);
        }

        [TestMethod]
        public void CreateIsVisibleAndEnabled()
        {
            Assert.IsTrue(form.createAccountButton.Visible);
            Assert.IsTrue(form.createAccountButton.Enabled);
        }

        [TestMethod]
        public void DepositIsVisibleAndEnabled()
        {
            Assert.IsTrue(form.depositButton.Visible);
            Assert.IsTrue(form.depositButton.Enabled);
        }

        [TestMethod]
        public void WithdrawIsVisibleAndEnabled()
        {
            Assert.IsTrue(form.withdrawButton.Visible);
            Assert.IsTrue(form.withdrawButton.Enabled);
        }

        [TestMethod]
        public void BalanceIsVisible()
        {
            Assert.IsTrue(form.balanceLabel.Visible);
        }
    }
}