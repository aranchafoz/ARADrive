using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text.RegularExpressions;
using ClientCADNS;
using ClientENns;
using BookingENns;
using BookingCADNS;

namespace Web
{
    public partial class Register : System.Web.UI.Page
    {
        bool invalid = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Button_Submit.Click += new EventHandler(this.Button_Submit_Click);
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
        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            
           if (!IsValidEmail(TextBox_Email.ToString())
                && TextBox_Address.ToString() != string.Empty && TextBox_Country.ToString() != string.Empty
                && TextBox_Name.ToString() != string.Empty && TextBox_PostalCode.ToString() != string.Empty
                && TextBox_Surname.ToString() != string.Empty && TextBox_Telephone.ToString() != string.Empty
                && TextBox_PasswordConfirm.ToString() != string.Empty && TextBox_EmailConfirm.ToString() != string.Empty
                && TextBox_Password.ToString() != string.Empty && TextBox_Location.ToString() != string.Empty)
            {
                if (TextBox_Email.ToString() == TextBox_EmailConfirm.ToString() && TextBox_Password.ToString() == TextBox_PasswordConfirm.ToString())
                {
                    int Telefono = Int32.Parse(TextBox_Telephone.Text);
                    Date Birthdate = BookingCAD.ConvertDate(TextBox_Birthdate.Text.ToString());
                    ClientEN client = new ClientEN(TextBox_Email.ToString(), TextBox_Password.ToString(), false, TextBox_NIF.ToString(), TextBox_Name.ToString(),
                        TextBox_Surname.ToString(), Telefono, TextBox_Address.ToString(), TextBox_Location.ToString(), null, true);
                    ClientCAD Client = new ClientCAD();
                }
            }
        }
    }
}