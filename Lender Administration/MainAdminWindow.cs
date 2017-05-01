using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Lender_Administration
{
    public partial class MainAdminWindow : Form
    {
        public string uri = Utilities.uri;
        private string userToken;
        private Dictionary<string, LenderModel> lenderObjectDict;
        private Dictionary<string, UserModel> userObjectDict;

        public MainAdminWindow(string userToken)
        {
            InitializeComponent();
            CenterToScreen();
            this.userToken = userToken;

            refreshLenders();
        }

        private void refreshLenders()
        {
            lenderObjectDict = new Dictionary<string, LenderModel>();
            var lenderOptions = new List<string>();
            var client = new RestClient(uri + "/lenders");
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "JWT " + userToken);
            IRestResponse response = client.Execute(request);
            Response r = JsonConvert.DeserializeObject<Response>(response.Content);
            foreach (var lender in r.Lenders)
            {
                if (!lender.lendercode.Equals("000"))
                {
                    lenderOptions.Add(lender.lendercode + " - " + lender.name);
                    lenderObjectDict[lender.lendercode] = lender;
                }
            }
            lenderList.DataSource = lenderOptions;
        }

        private void LenderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            userObjectDict = new Dictionary<string, UserModel>();
            var selectedLender = (string)lenderList.SelectedValue;
            var lendercode = Regex.Replace(selectedLender.Split('-')[0],@"\s","");

            var client = new RestClient(uri + "/users/" + lendercode);
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "JWT " + userToken);
            IRestResponse response = client.Execute(request);
            Response r = JsonConvert.DeserializeObject<Response>(response.Content);

            var dt = new DataTable();
            dt.Columns.Add("Username");
            foreach(var user in r.Users)
            {
                var row = dt.NewRow();
                row["Username"] = user.username;
                dt.Rows.Add(row);
                userObjectDict[user.username] = user;
            }
            userDisplayGrid.DataSource = dt;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
            base.OnFormClosing(e);
        }

        private void addLenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var name = "";
            var lendercode = "";

            //show form
            using (var form = new LenderInformationHandler())
            {
                if (form.ShowDialog(this) == DialogResult.Cancel)
                {
                    return;
                }
                name = form.name;
                lendercode = form.lendercode;
            }

            var client = new RestClient(uri + "/lender");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "JWT " + userToken);
            request.AddParameter("application/json", "{\n\t\"name\": \"" + name + "\",\n\t\"lendercode\": \"" + lendercode + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            refreshLenders();
            lenderList.SelectedText = name + " - " + lendercode;
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var previousSelection = lenderList.SelectedValue;
            var username = "";
            var password = "";
            var lendercode = Regex.Replace(((string)previousSelection).Split('-')[0], @"\s", "");

            //show form
            using (var form = new UserInformationHandler(lendercode))
            {
                if (form.ShowDialog(this) == DialogResult.Cancel)
                {
                    return;
                }
                username = form.username;
                password = form.hashedPassword;
            }

            var client = new RestClient(uri + "/user");
            var request = new RestRequest(Method.POST);
            request.AddHeader("authorization", "JWT " + userToken);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\n\t\"username\": \"" + username + "\",\n\t\"password\": \"" + password + "\",\n\t\"lendercode\": \"" + lendercode + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            refreshLenders();
            lenderList.SelectedItem = previousSelection;
        }

        private void editLenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedLender = (string)lenderList.SelectedValue;
            var lendercode = Regex.Replace(selectedLender.Split('-')[0], @"\s", "");
            var lender = lenderObjectDict[lendercode];
            var name = lender.name;
            var id = lender.id;

            //show form
            using (var form = new LenderInformationHandler(lendercode, name))
            {
                if (form.ShowDialog(this) == DialogResult.Cancel)
                {
                    return;
                }
                name = form.name;
            }

            var client = new RestClient(uri + "/lender");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("authorization", "JWT " + userToken);
            request.AddParameter("application/json", "{\n\t\"id\": " + id + ",\n\t\"name\": \"" + name + "\",\n\t\"lendercode\": \"" + lendercode + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            refreshLenders();
            lenderList.SelectedText = name + " - " + lendercode;
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userDisplayGrid.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please only have one row selected. Cannot mass edit.");
                return;
            }
            else if (userDisplayGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit from the grid.");
                return;
            }
            var previousSelection = lenderList.SelectedValue;
            
            var lendercode = Regex.Replace(((string)previousSelection).Split('-')[0], @"\s", "");
            var username = userDisplayGrid.SelectedRows[0].Cells[0].Value.ToString();
            var password = "";

            //show form
            using (var form = new UserInformationHandler(lendercode, username))
            {
                if (form.ShowDialog(this) == DialogResult.Cancel)
                {
                    return;
                }
                password = form.hashedPassword;
            }

            var client = new RestClient(uri + "/user");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("authorization", "JWT " + userToken);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\n\t\"username\": \"" + username + "\",\n\t\"password\": \"" + password + "\",\n\t\"lendercode\": \"" + lendercode + "\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            refreshLenders();
            lenderList.SelectedItem = previousSelection;
        }

        private void deleteLenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedLender = (string)lenderList.SelectedValue;
            var lendercode = Regex.Replace(selectedLender.Split('-')[0], @"\s", "");

            //ask for confirmation
            if (MessageBox.Show(this, "Are you sure you want delete this lender? Deleting this lender will also remove all users and applications related to this lender.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                return;
            }

            var client = new RestClient(uri + "/lender/" + lendercode);
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("authorization", "JWT " + userToken);
            IRestResponse response = client.Execute(request);

            refreshLenders();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (userDisplayGrid.SelectedRows.Count > 1)
            {
                MessageBox.Show("Please only have one row selected. Cannot mass edit.");
                return;
            }
            else if (userDisplayGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit from the grid.");
                return;
            }
            var previousSelection = lenderList.SelectedValue;
            var username = userDisplayGrid.SelectedRows[0].Cells[0].Value.ToString();

            //ask for confirmation
            if (MessageBox.Show(this, "Are you sure you want delete '" + username + "'", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
            {
                return;
            }

            var client = new RestClient(uri + "/user/" + username);
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("authorization", "JWT " + userToken);
            IRestResponse response = client.Execute(request);

            refreshLenders();
            lenderList.SelectedItem = previousSelection;
        }
    }
}
