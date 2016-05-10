using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DisenyoWeb
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button_Send.Click += new EventHandler(this.Button_Send_Click);
        }

        protected void Button_Send_Click(object sender, EventArgs e)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            MailMessage message = new MailMessage();
            try
            {
                MailAddress fromAddress = new MailAddress(TextBox_UserEmail.ToString(), TextBox_UserName.ToString());
                MailAddress toAddress = new MailAddress("aradrive.contact@gmail.com", "ARADrive");
                message.From = fromAddress;
                message.To.Add(toAddress);
                message.Subject = TextBox_Subject.ToString();
                message.Body = TextBox_Message.ToString();
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("aradrive.contact@gmail.com", "ucantreadme");
                smtpClient.Send(message);
                Label_Resultado.Text = "Message sent";
            }
            catch (Exception ex)
            {
                Label_Resultado.Text = "No se pudo enviar el mensaje!";
            }
        }
    }
}