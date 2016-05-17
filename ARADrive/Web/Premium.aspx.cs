using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClientCADNS;
using ClientENns;
using PaymentMethodENns;
using PaymentMethodCADNS;

namespace Web

{
    protected void Page_Load(object sender, EventArgs e)
    {
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
                nuevoPremium = clientCAD.updateCliente(client);
            }
        }
    }
}
