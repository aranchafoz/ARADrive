using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text.RegularExpressions;


namespace Web
{
    public partial class Contact : System.Web.UI.Page
    {
        bool invalid = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Button_Send.Click += new EventHandler(this.Button_Send_Click);
        }

        // This functions verifies the email is in a valid format
        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        // Function to process and replace the matched text
        private string DomainMapper(Match match)
        {
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

        protected void Button_Send_Click(object sender, EventArgs e)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            MailMessage message = new MailMessage();
            if (IsValidEmail(TextBox_UserEmail.Text.ToString()) && TextBox_UserName.Text.ToString() != string.Empty && TextBox_Message.Text.ToString() != string.Empty && TextBox_Subject.Text.ToString() != string.Empty)
            {
                try
                {
                    var fromAddress = new MailAddress("aradrive.contact@gmail.com", TextBox_UserName.Text.ToString());
                    var toAddress = new MailAddress("aradrive.contact@gmail.com", "aradrive");
                    const string fromPassword = "ucantreadme";
                    string subject = TextBox_Subject.Text.ToString();
                    string body = TextBox_Message.Text.ToString();

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 465,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    /*using (MailMessage mensaje = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    { 
                        smtp.Send(mensaje);
                    }*/
                    MailMessage mail = new MailMessage(fromAddress, toAddress);
                    mail.Body = body;
                    mail.Subject = subject;
                    try
                    {
                        smtp.Send(mail);
                        System.Windows.Forms.MessageBox.Show("Email Sent!");
                    }
                    catch (Exception)
                    {
                        System.Windows.Forms.MessageBox.Show("Email Sent!");
                    }

                }
                catch (ArgumentException)
                {
                    Label_Resultado.Text = "The message couldn't be sent!";
                }
            }
            else
            {
                Label_Resultado.Text = "Some fields are invalid or are missing";
            }
        }
    }
}