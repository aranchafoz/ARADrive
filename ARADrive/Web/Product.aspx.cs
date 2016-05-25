using BookingENns;
using BookingCADNS;
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
                    LoadData_ToCar(carCode, pickUp, dropOff);
                }
            }

            Button_Rent.Click += new EventHandler(Button_Rent_Click);
        }



        protected void Button_Rent_Click(object sender, EventArgs e)
        {
            // Check if all the Data is complete
            if (!Label_CarName.Text.Equals("no car selected") && !Label_CarPrice.Text.Equals("") &&
                !Label_CarCategory.Text.Equals("") && !Label_CarDescription.Text.Equals("") &&
                !Label_CarTransmission.Text.Equals("") && !Label_CarDoors.Text.Equals("") &&
                !Text_PickUp.Text.Equals("") && !Text_DropOff.Text.Equals(""))
            {
                // Get the dates from the Interface and the date for today
                Date date_PickUp = BookingCADNS.BookingCAD.ConvertDate(Text_PickUp.Text);
                Date date_DropOff = BookingCADNS.BookingCAD.ConvertDate(Text_DropOff.Text);
                DateTime dateTime_today = DateTime.Today;
                Date today = new Date(dateTime_today.Day, dateTime_today.Month, dateTime_today.Year);

                // Check if the PickUp-date is at least today and the DropOff-date not before the PickUp-date
                if ((Date.CompareDates(today, date_PickUp) >= 0) && Date.CompareDates(date_PickUp, date_DropOff) >= 0)
                {
                    // calculate actual total price
                    double totalPrice = Double.Parse(Label_CarPrice.Text) * (1 + BookingCAD.DayDifference(date_DropOff, date_PickUp));

                    // transfer relevant data to page "Rent.aspx"
                    Server.Transfer("Rent.aspx?code=" + carCode +
                                    "&pageOrigin=product" +
                                    "&totalPrice=" + totalPrice +
                                    "&datePickUp=" + Text_PickUp.Text +
                                    "&dateDropOff=" + Text_DropOff.Text);
                    Response.Redirect("Rent.aspx");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Please check the dates!");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please select the dates first!");
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
        }


        protected void LoadData_ToCar(int carCode, string pickUp, string dropOff)
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
            Text_PickUp.Text = pickUp;
            Text_DropOff.Text = dropOff;
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
