using System;
using System.Windows.Forms;

namespace Lender_Administration
{
    public partial class LenderInformationHandler : Form
    {
        public string lendercode;
        public string name;

        public LenderInformationHandler(string lendercode = null, string name = null)
        {
            InitializeComponent();
            CenterToScreen();
            if (lendercode != null)
            {
                lenderCodeInput.Text = lendercode;
                lenderCodeInput.ReadOnly = true;
            }
            if (name != null)
            {
                nameInput.Text = name;
            }
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            if (lenderCodeInput.Text.Length == 0 || nameInput.Text.Length == 0)
            {
                MessageBox.Show("No fields may be left empty.");
                return;
            }
            if (lenderCodeInput.Text.Length != 3)
            {
                MessageBox.Show("Lender Code must be 3 digits");
                return;
            }

            name = nameInput.Text;
            lendercode = lenderCodeInput.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
