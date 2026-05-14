using System;
using System.Windows.Forms;

namespace BankAccountApp
{
    public partial class OperationHistoryForm : Form
    {
        private BankAccount account;

        public OperationHistoryForm(BankAccount account)
        {
            InitializeComponent();
            this.account = account;

            RefreshHistory();
        }

        public void RefreshHistory()
        {
            historyListBox.Items.Clear();

            foreach (var item in account.GetOperationRecords())
            {
                historyListBox.Items.Add(item.ToString());
            }
        }
        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            if (account == null) return;
            account.ClearHistory();
            RefreshHistory();
            MessageBox.Show("История очищена!");
        }
    }
}
