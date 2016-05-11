using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
            try
            {
                if (IsValidEmail(TextBox_UserEmail.ToString()) && TextBox_UserName.ToString() != string.Empty && TextBox_Message.ToString() != string.Empty && TextBox_Subject.ToString() != string.Empty)
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
                else
                {
                    Label_Resultado.Text = "* Some fields are missing or invalid";
                }
            }
            catch (ArgumentException)
            {
                Label_Resultado.Text = "The message couldn't be sent!";
            }
        }
    }
}