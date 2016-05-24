using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using ClientENns;
using ClientCADNS;

namespace Web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // User isn't logged
            if(Session["user"] == null)
            {
                lnkProfile.Visible = false;
                lnkLog_in.Visible = true;
                lnkRegister.Visible = true;
                HyperLinkHello.Visible = false;
                ImageButton_Log_out.Visible = false;
            }
            // User is logged
            else
            {
                lnkProfile.Visible = true;
                lnkLog_in.Visible = false;
                lnkRegister.Visible = false;
                HyperLinkHello.Visible = true;
                ClientEN client = new ClientEN((ClientEN)Session["user"]);
                HyperLinkHello.Text = "Hello, " + client.Name.ToString();
                ImageButton_Log_out.Visible = true;

            }
        }

        protected void ImageButton_Log_out_Click(object sender, ImageClickEventArgs e)
        {
            ClientEN client = null;
            // Session variables
            Session["user"] = client;
            Response.Redirect("Home.aspx");
        }
    }
}