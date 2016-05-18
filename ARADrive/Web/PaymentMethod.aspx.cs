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
    public partial class Formulario_web2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is logged, in other case it's redirect to home
            if (Session["user"] == null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {

            string mail = (string)(Session[0]);
            PaymentMethodCAD aux = new PaymentMethodCAD();
            PaymentMethodEN comprobacion = aux.getPaymentMethod(mail);

            if(comprobacion.User == "user") {
                string user = TextBox_PaypalUser.Text.ToString();
                string pass = TextBox_PaypalPassword.Text.ToString();

                if (user != string.Empty && pass != string.Empty)
                {
                    PaymentMethodEN pago = new PaymentMethodEN(user, pass, mail);
                    PaymentMethodCAD insercion = new PaymentMethodCAD();
                    insercion.insertPaymentMethod(pago);
                }
                else
                { }
            }
            else
            { 
                TextBox_PaypalUser.Text = comprobacion.Client;
                TextBox_PaypalPassword.Text = comprobacion.Pass;
            }
        }
        }
}