﻿using BookingENns;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web
{
    public partial class Home : System.Web.UI.Page
    {
        private Date date_PickUp;
        private Date date_DropOff;
        private Date date_today;
        private double dayDifference;

        int carCode = -1;

        // hidden panel -> true
        // showed panel -> false

        protected void Page_Load(object sender, EventArgs e)
        {
            CollapsiblePanelExtender_Result.Collapsed = true;
            CollapsiblePanelExtender_Result.ClientState = "true";

            if (!IsPostBack)
                Button_Search.Click += new EventHandler(this.OnClick_Search);
        }


        protected void OnClick_Search(Object sender, EventArgs e)
        {

            // Check if dates are the correct format
            if (IsCorrectDateFormat(Calendar_PickUp1.Text) && IsCorrectDateFormat(Calendar_DropOff1.Text))
            {
                // Read PickUp- and DropOff-Date  +  get today's date
                date_PickUp = BookingCADNS.BookingCAD.ConvertDate(Calendar_PickUp1.Text);
                date_DropOff = BookingCADNS.BookingCAD.ConvertDate(Calendar_DropOff1.Text);
                date_today = new Date(DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);

                // Date_DropOff has to be at least Date_PickUp  &  Date_PickUp has to be at least today
                if ((Date.CompareDates(date_PickUp, date_DropOff) == 1) && (Date.CompareDates(date_today, date_PickUp) == 1))
                {
                    CollapsiblePanelExtender_Result.ExpandControlID = Button_Search.Text;
                    Label_Error.Text = "";
                    CollapsiblePanelExtender_Result.Collapsed = false;
                    CollapsiblePanelExtender_Result.ClientState = "false";



                    // calculate difference of the two dates
                    dayDifference = BookingCADNS.BookingCAD.DayDifference(date_DropOff, date_PickUp) + 1.0;

                    ShowCategoryAndTotalPrice();
                }
                else
                {
                    CollapsiblePanelExtender_Result.ExpandControlID = null;
                    CollapsiblePanelExtender_Result.Collapsed = true;
                    CollapsiblePanelExtender_Result.ClientState = "true";

                    Label_Error.Text = "Please check the dates!";
                }
            }
            else
            {
                CollapsiblePanelExtender_Result.ExpandControlID = null;
                CollapsiblePanelExtender_Result.Collapsed = true;
                CollapsiblePanelExtender_Result.ClientState = "true";
                System.Windows.Forms.MessageBox.Show("Please insert valid dates");
            }

        }

        protected void Home_ItemDataBound(Object sender, DataListCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "ClickSeeMore":
                    string dropOff = Calendar_DropOff1.Text;
                    string pickUp = Calendar_PickUp1.Text;
                    Label labelCarCode = e.Item.FindControl("Label_CarCode") as Label;
                    carCode = Int32.Parse(labelCarCode.Text);

                    string totalPrice = (e.Item.FindControl("Label_TotalPrice") as Label).Text;

                    Server.Transfer("Product.aspx?code=" + carCode +
                                    "&pageOrigin=home" +
                                    "&totalPrice=" + totalPrice +
                                    "&datePickUp=" + pickUp +
                                    "&dateDropOff=" + dropOff);
                    Response.Redirect("Product.aspx");
                    break;
            }

        }


        protected void ShowCategoryAndTotalPrice()
        {
            Label label_totalPrice = null;
            Label label_PricePerDay = null;
            Label label_category = null;

            try
            {
                foreach (DataListItem item in DataList_Consult.Items)
                {
                    // set category
                    label_category = item.FindControl("Label_CarCategory") as Label;
                    int cat = -1;
                    try
                    {
                        cat = Int32.Parse(label_category.Text);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    if (cat == 0)
                        label_category.Text = "Small Vehicle";
                    else if (cat == 1)
                        label_category.Text = "Medium Vehicle";
                    else if (cat == 2)
                        label_category.Text = "Larger Vehicle";
                    else if (cat == 3)
                        label_category.Text = "Enterprice Vehicle";


                    // set total price
                    label_totalPrice = item.FindControl("Label_TotalPrice") as Label;
                    label_PricePerDay = item.FindControl("Label_CarPrice") as Label;

                    double pricePerDay = -1.00;
                    try
                    {
                        pricePerDay = Double.Parse(label_PricePerDay.Text);
                        label_totalPrice.Text = (dayDifference * pricePerDay).ToString();
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                Label_Error.Text = "Couldn't show all data correctly! \n" + ex.ToString();

            }

        }

        public bool IsCorrectDateFormat(string date)
        {
            // correct format: "yyyy-MM-dd"

            string format = "yyyy-MM-dd";
            DateTime dateTime;
            if (DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out dateTime))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}