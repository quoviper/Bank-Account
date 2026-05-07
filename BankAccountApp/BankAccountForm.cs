using System;
using System.Windows.Forms;

namespace BankAccountApp
{
    public class BankAccountForm : Form
    {
        public BankAccount account;
        public TextBox nameTextBox;
        public TextBox amountTextBox;
        public Label nameLabel;
        public Label amountLabel;
        public Label balanceLabel;
        public Button createAccountButton;
        public Button depositButton;
        public Button withdrawButton;
        public BankAccountForm()
        {
            this.Text = "Управление банковским счётом";
            this.Width = 400;
            this.Height = 300;
            nameLabel = new Label
            {
                Location = new System.Drawing.Point(10, 10),
                Text = "Имя владельца",
                Width = 200,
            };
            nameTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 25),
                Width = 200,
            };
            amountLabel = new Label
            {
                Location = new System.Drawing.Point(10, 50),
                Text = "Сумма",
                Width = 200,
            };
            amountTextBox = new TextBox
            {
                Location = new System.Drawing.Point(10, 65),
                Width = 200,
            };
            createAccountButton = new Button
            {
                Location = new System.Drawing.Point(10, 100),
                Text = "Создать счёт",
                Width = 100
            };
            createAccountButton.Click += CreateAccountButton_Click;
            depositButton = new Button
            {
                Location = new System.Drawing.Point(120, 100),
                Text = "Пополнить",
                Width = 100
            };
            depositButton.Click += DepositButton_Click;
            withdrawButton = new Button
            {
                Location = new System.Drawing.Point(10, 130),
                Text = "Снять",
                Width = 210
            };
            withdrawButton.Click += WithdrawButton_Click;
            balanceLabel = new Label
            {
                Location = new System.Drawing.Point(10, 160),
                Width = 200,
                Height = 35
            };
            this.Controls.Add(nameTextBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(amountTextBox);
            this.Controls.Add(amountLabel);
            this.Controls.Add(createAccountButton);
            this.Controls.Add(depositButton);
            this.Controls.Add(withdrawButton);
            this.Controls.Add(balanceLabel);
        }
        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Введите имя владельца!");
                return;
            }
            if (string.IsNullOrEmpty(amountTextBox.Text))
            {
                MessageBox.Show("Введите начальную сумму!");
                return;
            }
            decimal initialBalance;
            if (!decimal.TryParse(amountTextBox.Text, out initialBalance) || initialBalance < 0)
            {
                MessageBox.Show("Неверный формат суммы!");
                return;
            }
            account = new BankAccount(nameTextBox.Text, initialBalance);
            balanceLabel.Text = $"Владелец счёта: {nameTextBox.Text}\nБаланс: {account.GetBalance()}";
            MessageBox.Show("Счёт создан!");
        }
        private void DepositButton_Click(object sender, EventArgs e)
        {
            if (account == null)
            {
                MessageBox.Show("Сначала создайте счёт!");
                return;
            }
            if (string.IsNullOrEmpty(amountTextBox.Text))
            {
                MessageBox.Show("Введите сумму для пополнения!");
                return;
            }
            decimal amount;
            if (!decimal.TryParse(amountTextBox.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Неверный формат суммы!");
                return;
            }
            try
            {
                account.Deposit(amount);
                balanceLabel.Text = $"Владелец счёта: {nameTextBox.Text}\nБаланс: {account.GetBalance()}";
                MessageBox.Show("Счёт пополнен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            if (account == null)
            {
                MessageBox.Show("Сначала создайте счёт!");
                return;
            }
            if (string.IsNullOrEmpty(amountTextBox.Text))
            {
                MessageBox.Show("Введите сумму для снятия!");
                return;
            }
            decimal amount;
            if (!decimal.TryParse(amountTextBox.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Неверный формат суммы!");
                return;
            }
            try
            {
                account.Withdraw(amount);
                balanceLabel.Text = $"Владелец счёта: {nameTextBox.Text}\nБаланс: {account.GetBalance()}";
                MessageBox.Show("Средства сняты!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}