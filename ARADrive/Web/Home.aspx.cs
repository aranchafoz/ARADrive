using BookingENns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Web
{
    //[System.Web.Script.Services.ScriptService]

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
            try
            {
                CollapsiblePanelExtender_Result.Collapsed = false;
                CollapsiblePanelExtender_Result.Collapsed = true;
                // Read Pick Up Date and Drop Off 
                date_PickUp = BookingCADNS.BookingCAD.ConvertDate(Calendar_PickUp1.Text);
                date_DropOff = BookingCADNS.BookingCAD.ConvertDate(Calendar_DropOff1.Text);
                date_today = new Date(DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);

                // Date_DropOff has to be at least Date_PickUp  &  Date_PickUp has to be at least today
                if ((date_DropOff.Equals(date_PickUp) > -1) && (date_PickUp.Equals(date_today) > -1))
                {
                    dayDifference = BookingCADNS.BookingCAD.DayDifference(date_DropOff, date_PickUp);
                    ShowResult();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Please check the dates!");
                }
            }
            catch (FormatException)
            {
                Label_Error.Text = "* Some fields are missing";
            }

        }


        protected void ShowResult()
        {
            Label label_totalPrice = null;
            Label label_PricePerDay = null;
            Label label_category = null;
            foreach (DataListItem item in DataList_Consult.Items)
            {
                // set total price
                label_totalPrice = item.FindControl("Label_TotalPrice") as Label;
                label_PricePerDay = item.FindControl("Label_CarPrice") as Label;
                //label_totalPrice.Text = (dayDifference * Int32.Parse(label_PricePerDay.Text)).ToString();

                // set category
                /*
                label_category = item.FindControl("category") as Label;
                int cat = Int32.Parse(label_category.Text);
                if (cat == 0)
                    label_category.Text = "Small Vehicle";
                else if (cat == 1)
                    label_category.Text = "Medium Vehicle";
                else if (cat == 2)
                    label_category.Text = "Larger Vehicle";
                else if (cat == 3)
                    label_category.Text = "Enterprice Vehicle";*/
            }


            /*
            Label_for_Result.Text = "DatePickUp: " + date_PickUp.ToString() +
                                        "DateDropOff: " + date_DropOff.ToString() +
                                            ", Daydiff: " + BookingCADNS.BookingCAD.DayDifference(date_DropOff, date_PickUp);
            */
        }

    }
}