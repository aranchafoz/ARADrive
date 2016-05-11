using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button_Submit.Click += new EventHandler(this.Button_Submit_Click);
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {

        }
    }
}