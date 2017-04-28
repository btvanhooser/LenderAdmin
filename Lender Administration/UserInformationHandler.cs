using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Lender_Administration
{
    public partial class UserInformationHandler : Form
    {
        public string hashedPassword;
        public string username;

        public UserInformationHandler(string lendercode, string username = null)
        {
            InitializeComponent();
            Text += " - " + lendercode;

            if (username != null)
            {
                usernameInput.Text = username;
                usernameInput.ReadOnly = true;
            }
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            if (passwordConfirm.Text.Length == 0 || passwordInput.Text.Length == 0 || usernameInput.Text.Length == 0)
            {
                MessageBox.Show("No fields may be left empty.");
                return;
            }
            if (!passwordInput.Text.Equals(passwordConfirm.Text))
            {
                MessageBox.Show("Password fields must match!");
                return;
            }

            username = usernameInput.Text;
            hashedPassword = getHashSha256(passwordInput.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public static string getHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
