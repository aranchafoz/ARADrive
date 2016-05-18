using BookingENns;
using ClientCADNS;
using ClientENns;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Drawing;
using System.Drawing.Configuration;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Drawing.Printing;
using System.Drawing.Imaging;

namespace Web
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is logged, in other case it's redirect to home
            if(Session["user"] == null)
            {
                Response.Redirect("Home.aspx");
            }

            if (!IsPostBack)
                Button_Edit.Click += new EventHandler(this.Button_Edit_Click);
        }

        // editable fields:
        // Text_UserPhone
        // Text_UserBirth
        // Text_UserCity
        // Text_UserAddress
        // Text_UserNIF
        // Text_UserDrivingLicense

        protected void Button_Edit_Click(object sender, EventArgs e)
        {
            // Saving client of user logged
            ClientEN client = new ClientEN((ClientEN)Session["user"]);

            string buttonText = Button_Edit.Text;
            // Edit mode
            if (buttonText.Equals("Save"))
            {
                if (Text_UserPhone.Text != "" && Text_UserBirth.Text != "" && Text_UserCity.Text != "" &&
                    Text_UserAddress.Text != "" && Text_UserNIF.Text != "" && Text_UserDrivingLicense.Text != "")
                {
                    Button_Edit.Text = "Edit";

                    TextBox2Label(Text_UserPhone);
                    TextBox2Label(Text_UserBirth);
                    TextBox2Label(Text_UserCity);
                    TextBox2Label(Text_UserAddress);
                    TextBox2Label(Text_UserNIF);
                    TextBox2Label(Text_UserDrivingLicense);


                    Date birthdate = ConvertDate(Text_UserBirth.Text);

                    bool drivingLicense = true;
                    if (Text_UserDrivingLicense.Text.Equals(""))
                        drivingLicense = false;

                    long telephone = ConvertPhonenumber(Text_UserPhone.Text);

                    SaveChanges(Label_UserEmail.Text, telephone, Text_UserNIF.Text,
                          birthdate, Text_UserAddress.Text, Text_UserCity.Text, drivingLicense);

                }
            }
            // Showing mode
            else if (buttonText.Equals("Edit"))
            {
                Button_Edit.Text = "Save";

                // Non-editable fields
                Label_UserName.Text = client.Name.ToString();
                Label_UserSurname.Text = client.Surname.ToString();
                Label_UserEmail.Text = client.Email.ToString();
                if(client.Premium == false)
                {
                    Label_UserPremium.Text = "Regular User";
                    //Label_UserPremium.ForeColor = new System.Drawing.ColorTranslator.FromHtml("#996600");
                }
                else
                {
                    Label_UserPremium.Text = "Premium User";
                    //Label_UserPremium.ForeColor = new System.Drawing.ColorTranslator.Green;
                }

                // Editable fields
                Text_UserPhone.Text = client.Phone.ToString();
                Text_UserBirth.Text = client.BirthDate.ToString();
                Text_UserCity.Text = client.City.ToString();
                Text_UserAddress.Text = client.Address.ToString();
                Text_UserNIF.Text = client.DNI.ToString();
                if (client.DrivingLicence == false)
                {
                    Text_UserDrivingLicense.Text = "None";
                }
                else
                {
                    Text_UserDrivingLicense.Text = "Valid";
                }
                /*
                Label2TextBox(Text_UserPhone);
                Label2TextBox(Text_UserBirth);
                Label2TextBox(Text_UserCity);
                Label2TextBox(Text_UserAddress);
                Label2TextBox(Text_UserNIF);
                Label2TextBox(Text_UserDrivingLicense);*/
            }

        }


        protected void SaveChanges(string email, long phone, string pass, Date birthDate,
            string address, string city, bool drivingLicense)
        {
            ClientCAD clientCAD = new ClientCAD();
            ClientEN cl = null;
            try
            {
                cl = clientCAD.getClient(email);

                cl.Address = address;
                cl.BirthDate = birthDate;
                cl.City = city;
                cl.DrivingLicence = drivingLicense;
                cl.Pass = pass;
                cl.Phone = phone;

                clientCAD.updateClient(cl);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Changes could not be saved!");
                // possible reasons for fail:
                // -> email could not be found in DB
                // -> Errors at updateClient
            }

        }


        protected void TextBox2Label(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.None;
            textBox.BackColor = System.Drawing.Color.Transparent;
            textBox.ReadOnly = true;
        }

        protected void Label2TextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.Solid;
            textBox.BackColor = System.Drawing.Color.White;
            textBox.ReadOnly = false;
        }


        // "27/04/1982"
        protected static Date ConvertDate(string text)
        {
            DateTime datetime = DateTime.ParseExact(text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return new Date(datetime.Day, datetime.Month, datetime.Year);
        }

        // "+34 622 10 41 88"
        protected static long ConvertPhonenumber(string number)
        {
            string phoneNumber = "";

            for (int i = 0; i < number.Length; i++)
            {
                if (Regex.IsMatch(number.Substring(i, 1), @"([0-9])",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                    phoneNumber += number.Substring(i, 1);
            }
            return Int64.Parse(phoneNumber);
        }

    }
}