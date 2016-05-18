using ClientCADNS;
using ClientENns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Log_in : System.Web.UI.Page
    {
        private string email;
        private string password;

        protected void Page_Load(object sender, EventArgs e)
        {
            Button_Submit.Click += new EventHandler(this.Button_Submit_Click);
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            // get email and password of fields
            this.email = TextBox_Email.Text.ToString();
            this.password = TextBox_Password.Text.ToString();

            ClientCAD clientCAD = new ClientCAD();
            ClientEN client = clientCAD.getClient(email);

            if (client.Pass.Equals(password))
            {
                Session.Add(client.Email, client);
                System.Windows.Forms.MessageBox.Show("Login was successful");
                TextBox_Email.Text = "";
                TextBox_Password.Text = "";
            }
            else
            {

            }
        }
    }
}