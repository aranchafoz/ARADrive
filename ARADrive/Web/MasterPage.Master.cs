﻿using System;
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

            }
        }
    }
}