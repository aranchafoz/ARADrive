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
using System.Web.SessionState;

namespace Web
{
    public partial class PaymentMethod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is logged, in other case it's redirect to home
            if (Session["user"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                // Load user logged from session variable
                ClientEN client = new ClientEN((ClientEN)Session["user"]);

                PaymentMethodCAD aux = new PaymentMethodCAD();
                PaymentMethodEN comprobacion = aux.getPaymentMethod(client.Email);

                if(!(comprobacion.Client.Equals("")))
                {
                    TextBox_PaypalUser.Text = comprobacion.Client;
                    TextBox_PaypalPassword.Text = comprobacion.Pass;
                }                
            }

        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {

            // Load user logged from session variable
            ClientEN client = new ClientEN((ClientEN)Session["user"]);

            string mail = client.Email;


            // User dont have a payment method yet
            //if (comprobacion.User == null)
            //{
                string user = TextBox_PaypalUser.Text;
                string pass = TextBox_PaypalPassword.Text;

                if (user != string.Empty && pass != string.Empty)
                {
                    //PaymentMethodEN pago = new PaymentMethodEN(user, pass, mail);
                    PaymentMethodCAD insercion = new PaymentMethodCAD();
                    PaymentMethodEN pago = new PaymentMethodEN(user, pass, mail);

                    PaymentMethodCAD paymentCAD = new PaymentMethodCAD();
                    PaymentMethodEN payment = paymentCAD.getPaymentMethod(mail);

                    if (payment.Client.Equals(""))
                    {
                        insercion.insertPaymentMethod(pago);
                    }
                    else
                    {
                        insercion.updatePaymentMethod(pago);
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Some fields are not completed");
                }
            //}
            // User already have a payment method
            //else
            //{
                //System.Windows.Forms.MessageBox.Show("You already have a payment method registed!");
                /*
                TextBox_PaypalUser.Text = comprobacion.Client;
                TextBox_PaypalPassword.Text = comprobacion.Pass;
                */
            //}
        }
    }
}