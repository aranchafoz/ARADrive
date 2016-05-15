using BookingENns;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            Button_Search.Click += new EventHandler(this.OnClick_Search);
        }


        protected void OnClick_Search(Object sender, EventArgs e)
        {
            Label_Error.Text = "MOSTRANDO!!";
            CollapsiblePanelExtender_Result.Collapsed = false;
            CollapsiblePanelExtender_Result.Collapsed = true;

            // Check if dates are the correct format
            if (IsCorrectDateFormat(Calendar_PickUp1.Text) && IsCorrectDateFormat(Calendar_DropOff1.Text))
                {
                    // Read PickUp- and DropOff-Date  +  get today's date
                    date_PickUp = BookingCADNS.BookingCAD.ConvertDate(Calendar_PickUp1.Text);
                    date_DropOff = BookingCADNS.BookingCAD.ConvertDate(Calendar_DropOff1.Text);
                    date_today = new Date(DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);

                    // Date_DropOff has to be at least Date_PickUp  &  Date_PickUp has to be at least today
                    if ((Date.CompareDates(date_PickUp, date_DropOff) < 1) && (Date.CompareDates(date_today, date_PickUp) < 1))
                    { 
                        // calculate difference of the two dates
                        dayDifference = BookingCADNS.BookingCAD.DayDifference(date_DropOff, date_PickUp);

                        ShowResult();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Please check the dates!");
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Please check the format of your date!");
                }
            

        }


        protected void ShowResult()
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


            /*
            Label_for_Result.Text = "DatePickUp: " + date_PickUp.ToString() +
                                        "DateDropOff: " + date_DropOff.ToString() +
                                            ", Daydiff: " + BookingCADNS.BookingCAD.DayDifference(date_DropOff, date_PickUp);
            */
        }

        public bool IsCorrectDateFormat (string date)
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