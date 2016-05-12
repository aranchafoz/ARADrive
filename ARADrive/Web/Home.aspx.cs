using BookingENns;
using System;
using System.Collections.Generic;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            Button_Search.Click += new EventHandler(this.OnClick_Search);
        }


        protected void OnClick_Search(Object sender, EventArgs e)
        {
            // Read Pick Up Date and Drop Off 
            date_PickUp = BookingCADNS.BookingCAD.ConvertDate(Calendar_PickUp1.Text);
            date_DropOff = BookingCADNS.BookingCAD.ConvertDate(Calendar_DropOff1.Text);
            date_today = new Date(DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);

            // Date_DropOff has to be at least Date_PickUp  &  Date_PickUp has to be at least today
            if ((date_DropOff.Equals(date_PickUp) > -1) && (date_PickUp.Equals(date_today) > -1))
            {
                ShowResult();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please check the dates!");
            }

        }


        protected void ShowResult()
        {
            /*
            Label_for_Result.Text = "DatePickUp: " + date_PickUp.ToString() +
                                        "DateDropOff: " + date_DropOff.ToString() +
                                            ", Daydiff: " + BookingCADNS.BookingCAD.DayDifference(date_DropOff, date_PickUp);
            */
        }
        
    }
}