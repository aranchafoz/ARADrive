using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClientCADNS;
using ClientENns;
using PaymentMethodENns;
using PaymentMethodCADNS;
using System;
using System.Linq;

namespace Web

{
    public partial class Premium : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Se ha añadido try/catch en el CAD, mirar porque se produce Exception
            try {
                string mail = (string)(Session[0]);


                ClientCAD clientCAD = new ClientCAD();
                ClientEN client = clientCAD.getClient(mail);
                PaymentMethodCAD paymentCAD = new PaymentMethodCAD();
                PaymentMethodEN payment = paymentCAD.getPaymentMethod(mail);

                if (client.Premium == true)
                {
                    Button_PremiumUser.Text = "Selected";
                    Button_PremiumUser.Enabled = false;

                }
            }catch(ArgumentOutOfRangeException)
            {
                System.Windows.Forms.MessageBox.Show("Mail not registered, please log in");
            }
        }
        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            string mail = (string)(Session[0]);
         

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
                    clientCAD.updateClient(client);
                }
            }
        }
    }
}
