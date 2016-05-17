using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClientCADNS;
using ClientENns;
using PaymentMethodENns;
using PaymentMethodCADNS;

namespace Web
{
    public partial class Premium : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            string mail = (string)(Session[0]);
            bool nuevoPremium = false;

            ClientCAD clientCAD = new ClientCAD();
            ClientEN client = clientCAD.getClient(mail);
            PaymentMethodCAD paymentCAD = new PaymentMethodCAD();
            PaymentMethodEN payment = paymentCAD.getPaymentMethod(mail);

            if (client.Premium == true)
            {
                Button_PremiumUser.Text = "Already Premium";
            }
            else
            {
                if (payment.User != "user")
                {
                    client.Premium = true;
                    nuevoPremium = clientCAD.updateClient(client);
                }
            }
        }
    }
}