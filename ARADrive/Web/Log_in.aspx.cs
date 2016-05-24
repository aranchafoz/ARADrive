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
            if (!IsPostBack)
                Button_Submit.Click += new EventHandler(this.Button_Submit_Click);
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            ClientEN client = null;

            // get email and password of fields
            if ((!TextBox_Email.Text.Equals("")) && (!TextBox_Password.Text.Equals("")))
            {
                this.email = TextBox_Email.Text.ToString();
                this.password = TextBox_Password.Text.ToString();

                try
                {
                    ClientCAD clientCAD = new ClientCAD();
                    client = clientCAD.getClient(email);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Mail not in database -- " + ex.ToString());
                }

                if (client.Pass.Equals(password) && (client != null))
                {
                    Session.Add(client.Email, client.Name);
                    // Session variables
                    Session["user"] = client;

                    //System.Windows.Forms.MessageBox.Show("Login was successful");
                    TextBox_Email.Text = "";
                    TextBox_Password.Text = "";
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Incorrect password");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please enter Email and Password!");
            }
        }
    }
}