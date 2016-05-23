using BookingENns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Product : System.Web.UI.Page
    {
        int carCode;
        string userID;
        string dropOff;
        string pickUp;

        protected void Page_Load(object sender, EventArgs e)
        {
            // basically set labels to >>no car<<
            Label_CarName.Text = "no car selected";
            Label_CarPrice.Text = "";
            Label_CarCategory.Text = "";
            Label_CarDescription.Text = "";
            Label_CarTransmission.Text = "";
            Label_CarDoors.Text = "";
            CarImage.ImageUrl = "assets/img/carPics/polo.png";
            Label_TotalPrice.Text = "-";

            // check if we came here from page CATALOG or HOME
            if (Request.Params.AllKeys.Contains("code") && Request.Params.AllKeys.Contains("pageOrigin"))
            {
                if (Request.Params["pageOrigin"].Equals("catalog"))
                {
                    carCode = Int32.Parse(Request.Params["code"]);
                    LoadData_ToCar(carCode);
                }
                else if (Request.Params["pageOrigin"].Equals("home"))
                {
                    carCode = Int32.Parse(Request.Params["code"]);
                    dropOff = Request.Params["dateDropOff"];
                    pickUp = Request.Params["datePickUp"];
                    LoadData_ToCar(carCode);
                }

            }

            Button_Rent.Click += new EventHandler(Button_Rent_Click);
        }


        protected void Button_Rent_Click(object sender, EventArgs e)
        {
            int bookingCode = 1;
            if (Session["user"] == null)
                System.Windows.Forms.MessageBox.Show("Please login first!");
            else
            {
                ClientENns.ClientEN client = new ClientENns.ClientEN((ClientENns.ClientEN)Session["user"]);
                userID = client.Email;

                if (!Label_CarName.Text.Equals("no car selected") && !Label_CarPrice.Text.Equals("") &&
                !Label_CarCategory.Text.Equals("") && !Label_CarDescription.Text.Equals("") &&
                !Label_CarTransmission.Text.Equals("") && !Label_CarDoors.Text.Equals("") &&
                !Text_PickUp.Text.Equals("") && !Text_DropOff.Text.Equals("") &&
                !Label_TotalPrice.Text.Equals("-"))
                {
                    //try
                    //{
                        DateTime today = DateTime.Today;
                        Date dateInicio = new Date(today.Day, today.Month, today.Year);

                        //Date birthdate = BookingCADNS.BookingCAD.ConvertDate()
                        //bool youngDriver 

                        // DatePickUp

                        // DateDelivery

                        double price = Double.Parse(Label_TotalPrice.Text);

                        BookingCADNS.BookingCAD bookingCAD = new BookingCADNS.BookingCAD();
                        BookingEN myBooking = new BookingEN
                            (bookingCode, userID, carCode, dateInicio, dateInicio, false, false, false, false, false, false, false, 1, 1, price);
                        bookingCAD.insertBooking(myBooking);
                        bookingCode++;

                        System.Windows.Forms.MessageBox.Show("Booking saved!");
                        /*}
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show("Something went wrong at storing the booking! - " + ex.Message);
                        }*/

                    }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Please select the dates first!");
                    Response.Redirect("Home.aspx");
                }
            }
        }


        protected void LoadData_ToCar(int carCode)
        {
            CarCADNS.CarCAD carCAD = new CarCADNS.CarCAD();
            CarENns.CarEN car = carCAD.getCar(carCode);

            Label_CarName.Text = car.Name;
            Label_CarPrice.Text = car.Price.ToString();
            Label_CarCategory.Text = GetCarCategoryText(car.Category);
            Label_CarDescription.Text = car.Desc;
            Label_CarTransmission.Text = car.AutomaticTransmission.ToString();
            Label_CarDoors.Text = car.Doors.ToString();
            CarImage.ImageUrl = "assets/img/carPics/" + car.IMG;
            Text_PickUp.Text = "2016-05-22";
            Text_DropOff.Text = "2016-05-24";
            Label_TotalPrice.Text = GetTotalPrice().ToString();
        }


        protected double GetTotalPrice()
        {
            double totalPrice = 0.0;

            try
            {
                Date pickup_date = BookingCADNS.BookingCAD.ConvertDate(Text_PickUp.Text);
                Date dropoff_date = BookingCADNS.BookingCAD.ConvertDate(Text_DropOff.Text);

                try
                {
                    double pricePerDay = Double.Parse(Label_CarPrice.Text);

                    // calculate difference of the two dates
                    double dayDifference = BookingCADNS.BookingCAD.DayDifference(dropoff_date, pickup_date) + 1.0;

                    totalPrice = dayDifference * pricePerDay;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Couldn't show all data correctly! \n" + ex.ToString());

            }

            return totalPrice;

        }


        protected string GetCarCategoryText(int cat)
        {
            string result = null;
            if (cat == 0)
                result = "Small Vehicle";
            else if (cat == 1)
                result = "Medium Vehicle";
            else if (cat == 2)
                result = "Larger Vehicle";
            else if (cat == 3)
                result = "Enterprise Vehicle";

            return result;
        }

        protected int GetCarCategoryCode(string labelCategory)
        {
            int result = -1;
            if (labelCategory.Equals("Small Vehicle"))
                result = 0;
            else if (labelCategory.Equals("Medium Vehicle"))
                result = 1;
            else if (labelCategory.Equals("Larger Vehicle"))
                result = 2;
            else if (labelCategory.Equals("Enterprise Vehicle"))
                result = 3;

            return result;
        }

    }
}
          