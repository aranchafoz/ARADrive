using BookingCADNS;
using BookingENns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Rent : System.Web.UI.Page
    {
        private int carCode;
        protected double totalPrice;
        private double finalPrice;
        private Date pickUp;
        private Date dropOff;
        private string stringPickUp;
        private string stringDropOff;

        private bool driver = false;
        private bool gps = false;
        private bool insurance = false;
        private bool babyChair = false;
        private bool childChair = false;
        private bool baca = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["pageOrigin"].Equals("product"))
            {
                // get all the data from page "Product"
                carCode = Int32.Parse(Request.Params["code"]);
                totalPrice = Double.Parse(Request.Params["totalPrice"]);
                stringPickUp = Request.Params["datePickUp"];
                pickUp = BookingCADNS.BookingCAD.ConvertDate(stringPickUp);
                stringDropOff = Request.Params["dateDropOff"];
                dropOff = BookingCADNS.BookingCAD.ConvertDate(stringDropOff);

                Label_TotalPrice.Text = totalPrice.ToString();
            }


            // not necessary because already in Rent.aspx defined
            // Button_Rent.Click += new EventHandler(Button_Rent_Click);

            Button_Driver.Click += new EventHandler(AddDriver);
            Button_GPS.Click += new EventHandler(AddGPS);
            Button_Baca.Click += new EventHandler(AddBaca);
            Button_BabyChair.Click += new EventHandler(AddBabyChair);
            Button_ChildChair.Click += new EventHandler(AddChildChair);
            Button_Insurance.Click += new EventHandler(AddInsurance);
        }

        protected void Button_Rent_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                System.Windows.Forms.MessageBox.Show("Please login first!");
            else
            {
                ClientENns.ClientEN client = new ClientENns.ClientEN((ClientENns.ClientEN)Session["user"]);
                string userID = client.Email;

                if (!Label_TotalPrice.Text.Equals("-"))
                {
                    try
                    {
                        BookingCAD aux = new BookingCAD();

                        int bookingCode = aux.getLastBookingCode() + 1;
                        double price = computeFinalPrice();

                        BookingCADNS.BookingCAD bookingCAD = new BookingCADNS.BookingCAD();
                        BookingEN myBooking = new BookingEN
                            (bookingCode, userID, carCode, pickUp, dropOff, driver, gps, babyChair, childChair, baca, insurance, false, 1, 1, price);
                        bookingCAD.insertBooking(myBooking);
                        bookingCode++;

                        System.Windows.Forms.MessageBox.Show("Booking saved!");
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Something went wrong at storing the booking! - " + ex.Message);
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Something went wrong - Total Price is missing!");
                }
            }
        }


        protected void AddDriver(object sender, EventArgs e)
        {
            if (Button_Driver.Text.Equals("Select") && IsPostBack)
            {

                driver = true;
                Button_Driver.CssClass = "btn btn-danger";
                Button_Driver.Text = "Remove";
            }
            else if (Button_Driver.Text.Equals("Remove") && IsPostBack)
            {
                driver = false;
                Button_Driver.CssClass = "btn";
                Button_Driver.Text = "Select";
            }
            Label_TotalPrice.Text = computeFinalPrice().ToString();
        }

        protected void AddGPS(object sender, EventArgs e)
        {
            if (Button_GPS.Text.Equals("Select") && IsPostBack)
            {

                gps = true;
                Button_GPS.CssClass = "btn btn-danger";
                Button_GPS.Text = "Remove";
            }
            else if (Button_GPS.Text.Equals("Remove") && IsPostBack)
            {
                gps = false;
                Button_GPS.CssClass = "btn";
                Button_GPS.Text = "Select";
            }
            Label_TotalPrice.Text = computeFinalPrice().ToString();
        }

        protected void AddBaca(object sender, EventArgs e)
        {
            if (Button_Baca.Text.Equals("Select") && IsPostBack)
            {

                baca = true;
                Button_Baca.CssClass = "btn btn-danger";
                Button_Baca.Text = "Remove";
            }
            else if (Button_Baca.Text.Equals("Remove") && IsPostBack)
            {
                baca = false;
                Button_Baca.CssClass = "btn";
                Button_Baca.Text = "Select";
            }
            Label_TotalPrice.Text = computeFinalPrice().ToString();
        }

        protected void AddBabyChair(object sender, EventArgs e)
        {
            if (Button_BabyChair.Text.Equals("Select") && IsPostBack)
            {

                babyChair = true;
                Button_BabyChair.CssClass = "btn btn-danger";
                Button_BabyChair.Text = "Remove";
            }
            else if (Button_BabyChair.Text.Equals("Remove") && IsPostBack)
            {
                babyChair = false;
                Button_BabyChair.CssClass = "btn";
                Button_BabyChair.Text = "Select";
            }
            Label_TotalPrice.Text = computeFinalPrice().ToString();
        }

        protected void AddChildChair(object sender, EventArgs e)
        {
            if (Button_ChildChair.Text.Equals("Select") && IsPostBack)
            {

                childChair = true;
                Button_ChildChair.CssClass = "btn btn-danger";
                Button_ChildChair.Text = "Remove";
            }
            else if (Button_ChildChair.Text.Equals("Remove") && IsPostBack)
            {
                childChair = false;
                Button_ChildChair.CssClass = "btn";
                Button_ChildChair.Text = "Select";
            }
            Label_TotalPrice.Text = computeFinalPrice().ToString();
        }

        protected void AddInsurance(object sender, EventArgs e)
        {
            if (Button_Insurance.Text.Equals("Select") && IsPostBack)
            {

                insurance = true;
                Button_Insurance.CssClass = "btn btn-danger";
                Button_Insurance.Text = "Remove";
            }
            else if (Button_Insurance.Text.Equals("Remove") && IsPostBack)
            {
                insurance = false;
                Button_Insurance.CssClass = "btn";
                Button_Insurance.Text = "Select";
            }
            Label_TotalPrice.Text = computeFinalPrice().ToString();
        }
        
        protected double computeFinalPrice() {
            finalPrice = totalPrice;
            if(driver)
                finalPrice += Double.Parse(Label_DriverPrice.Text);
            if (gps)
                finalPrice += Double.Parse(Label_GPSPrice.Text);
            if (insurance)
                finalPrice += Double.Parse(Label_InsurancePrice.Text);
            if (baca)
                finalPrice += Double.Parse(Label_BacaPrice.Text);
            if (babyChair)
                finalPrice += Double.Parse(Label_BabyChairPrice.Text);
            if (childChair)
                finalPrice += Double.Parse(Label_ChildChairPrice.Text);

            return finalPrice;
        }

    }
}
