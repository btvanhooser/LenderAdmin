using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lender_Administration
{
    public partial class Form1 : Form
    {
        public string uri = Utilities.uri;

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var username = usernameInput.Text;
            var password = getHashSha256(passwordInput.Text);
            var userToken = checkIfValidUser(username, password);
            if (userToken == null)
            {
                MessageBox.Show("Incorrect Authentication");
            }
            else if (userToken.Equals("-1"))
            {
                MessageBox.Show("Insufficient Permissions. Must be a member of the 000 lender.");
            }
            else
            {
                MainAdminWindow mainWindow = new MainAdminWindow(userToken);
                mainWindow.Show(this);
                Hide();
            }
        }

        private string checkIfValidUser(string username, string password)
        {
            var client = new RestClient(uri + "/auth");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\n\t\"username\": \"" + username + "\",\n\t\"password\": \"" + password + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            Response r = JsonConvert.DeserializeObject<Response>(response.Content);
            var accessToken = r.access_token;

            if (accessToken == null)
            {
                return accessToken;
            }

            client = new RestClient(uri + "/lender");
            request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "JWT " + accessToken);
            response = client.Execute(request);

            LenderModel L = JsonConvert.DeserializeObject<LenderModel>(response.Content);
            if (L.lendercode.Equals("000"))
            {
                return accessToken;
            }
            return "-1";
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
