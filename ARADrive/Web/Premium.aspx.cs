using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClientCADNS;
using ClientENns;
using PaymentMethodENns;
using PaymentMethodCADNS;
using System;
using System.Linq;
using System.Web.SessionState;

namespace Web

{
    public partial class Premium : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is logged, in other case it's redirect to home
            if (Session["user"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            // Se ha añadido try/catch en el CAD, mirar porque se produce Exception
            try
            {
                ClientEN client = new ClientEN((ClientEN)Session["user"]);
                string Mail1 = client.Email.ToString();
                ClientCAD clientCAD = new ClientCAD();
                ClientEN client2 = clientCAD.getClient(Mail1);
                PaymentMethodCAD paymentCAD = new PaymentMethodCAD();
                PaymentMethodEN payment = paymentCAD.getPaymentMethod(Mail1);

                if (client.Premium == true)
                {
                    Button_PremiumUser.Text = "Selected";
                    Button_PremiumUser.Enabled = false;

                }
            }
            catch (ArgumentOutOfRangeException)
            {
                System.Windows.Forms.MessageBox.Show("Mail not registered, please log in");
            }
        }
        protected void Button_Submit_Click(object sender, EventArgs e)
        {


            ClientEN client = new ClientEN((ClientEN)Session["user"]);
            string Mail1 = client.Email.ToString();
            ClientCAD clientCAD = new ClientCAD();
            ClientEN client2 = clientCAD.getClient(Mail1);
            PaymentMethodCAD paymentCAD = new PaymentMethodCAD();
            PaymentMethodEN payment = paymentCAD.getPaymentMethod(Mail1);

            if (client.Premium == true)
            {
                Button_PremiumUser.Text = "Already Premium";
            }
            else
            {
                if (payment.User != "user")
                {
                    client.Premium = true;
                    clientCAD.updateClient(client);
                }
                else
                {
                    if (payment.User == "user")
                    {
                        System.Windows.Forms.MessageBox.Show("You upgrade was successfull");
                    }
                    else
                    {
                        Button_PremiumUser.Text = "Selected";
                        Button_PremiumUser.Enabled = false;
                        client.Premium = true;
                        clientCAD.updateClient(client);

                    }
                }
            }
        }
    }
}
