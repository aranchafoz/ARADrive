﻿using System;
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
        Date today = new Date(DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);
        Date minima = new Date(DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year - 12);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Button_Submit.Click += new EventHandler(this.Button_Submit_Click);
        }

        static bool ValidateNumber(string number)
        {
            bool adevolver = true;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] < 48 || number[i] > 57)
                {
                    adevolver = false;
                    break;
                }
            }
            return adevolver;
        }

        static bool ValidatePassword(string password)
        {
            const int MIN_LENGTH = 8;
            const int MAX_LENGTH = 15;

            if (password == null) throw new ArgumentNullException();

            bool meetsLengthRequirements = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;

            if (meetsLengthRequirements)
            {
                foreach (char c in password)
                {
                    if (char.IsLower(c)) hasLowerCaseLetter = true;
                    else if (char.IsDigit(c)) hasDecimalDigit = true;
                }
            }

            bool isValid = meetsLengthRequirements
                        && hasLowerCaseLetter
                        && hasDecimalDigit
                        ;
            return isValid;

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
            string email = TextBox_Email.Text;
            string emailConfirm = TextBox_EmailConfirm.Text;
            string password = TextBox_Password.Text;
            string passwordConfirm = TextBox_PasswordConfirm.Text;
            string dni = TextBox_NIF.Text;
            string name = TextBox_Name.Text;
            string surname = TextBox_Surname.Text;
            string bd = TextBox_Birthdate.Text;
            string telephone = TextBox_Telephone.Text;
            string address = TextBox_Address.Text;
            string country = TextBox_Country.Text;
            string postalcode = TextBox_PostalCode.Text;
            string location = TextBox_Location.Text;
            bool drivingLicense = CheckBox_DrivingLicense.Checked;

            // FOR TESTING: 
            /*string email = "tina@brunner.de";
            string emailConfirm = "tina@brunner.de";
            string password = "Asdf1234";
            string passwordConfirm = "Asdf1234";
            string dni = "394583H";
            string name = "Brunner";
            string surname = "Tina";
            //string bd = "1993-05-26";
            string telephone = "659448372";
            string address = "Street 1";
            string country = "Germany";
            string postalcode = "49302";
            string location = "Munich";
            bool drivingLicense = false;*/


            try
            {
                if (address != string.Empty && country != string.Empty && postalcode != string.Empty
                    && name != string.Empty && surname != string.Empty && bd != string.Empty
                    && telephone != string.Empty && email != string.Empty && dni != string.Empty
                    && password != string.Empty && passwordConfirm != string.Empty
                    && location != string.Empty)
                {
                    Date birthdate = BookingCAD.ConvertDate(bd);
                    if (email.Equals(emailConfirm))
                    {
                        if (IsValidEmail(email))
                        {
                            if (password.Equals(passwordConfirm))
                            {
                                if (ValidatePassword(password))
                                {
                                    if (ValidateNumber(postalcode))
                                    {
                                        if (ValidateNumber(telephone))
                                        {
                                            if (Date.CompareDates(birthdate, today) == 1)
                                            {
                                                if (Date.CompareDates(birthdate, minima) == 1)
                                                {
                                                    if (CheckBox_DrivingLicense.Checked)
                                                    {
                                                        if (ValidateNumber(TextBox_DrivingLicenseNumber.Text.ToString()))
                                                        {
                                                            Date licencia = BookingCAD.ConvertDate(TextBox_DrivingLicenseDueDate.Text.ToString());
                                                            if (Date.CompareDates(today, licencia) == 1)
                                                            {
                                                                long telefono = Convert.ToInt64(telephone);
                                                                //System.Windows.Forms.MessageBox.Show(birthdate.ToString());
                                                                ClientEN clientEN = new ClientEN(email, password, false, dni, name, surname, telefono,
                                                                    address, location, birthdate, drivingLicense);
                                                                ClientCAD clientCAD = new ClientCAD();
                                                                clientCAD.insertCliente(clientEN);
                                                                Label_Error.Text = "Welcome to ARADrive!";
                                                            }
                                                            else
                                                            {
                                                                Label_Error.Text = "Driving license due date not valid";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Label_Error.Text = "Driving license not valid";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        long telefono = Convert.ToInt64(telephone);
                                                        //System.Windows.Forms.MessageBox.Show(birthdate.ToString());
                                                        ClientEN clientEN = new ClientEN(email, password, false, dni, name, surname, telefono,
                                                            address, location, birthdate, drivingLicense);
                                                        ClientCAD clientCAD = new ClientCAD();
                                                        clientCAD.insertCliente(clientEN);
                                                        Label_Error.Text = "Welcome to ARADrive!";
                                                    }
                                                }
                                                else
                                                {
                                                    Label_Error.Text = "You have to be at least 15";
                                                }
                                            }
                                            else
                                            {
                                                Label_Error.Text = "Invalid birthdate";
                                            }
                                        }
                                        else
                                        {
                                            Label_Error.Text = "Telephone can only have numbers";
                                        }
                                    }
                                    else
                                    {
                                        Label_Error.Text = "Postal code not valid";
                                    }
                                }
                                else
                                {
                                    Label_Error.Text = "Password not strong enough";
                                }
                            }
                            else
                            {
                                Label_Error.Text = "Password fields mismatch";
                            }
                        }
                        else
                        {
                            Label_Error.Text = "Mail not valid";
                        }
                    }
                    else
                    {
                        Label_Error.Text = "Mail fields mismatch";
                    }
                }
                else
                {
                    Label_Error.Text = "Some fields are missing";
                }
            }
            catch (NullReferenceException)
            {
                Label_Error.Text = "Error creating account";
            }
        }
    }
}