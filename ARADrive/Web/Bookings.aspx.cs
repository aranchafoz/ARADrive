using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using ClientENns;

namespace Web
{
    public partial class Bookings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is logged, in other case it's redirect to home
            if (Session["user"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            ShowBookings();
        }

        protected void ShowBookings()
        {
            // Loading client of user logged
            ClientEN client = new ClientEN((ClientEN)Session["user"]);

            try
            {
                foreach (DataListItem item in DataListBookings.Items)
                {
                    Label label_user = item.FindControl("Label_User") as Label;
                    string user = label_user.Text.ToString();
                    if (user.Equals(client.Email))
                    {
                        item.FindControl("PanelItem").Visible = true;
                    }

                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Could not load the data correctly!");

            }
        }
                

        protected void DataListBookings_ItemCommand(object source, DataListCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "ClickDelete":

                    Label labelBookingCode = e.Item.FindControl("Label_BookingCode") as Label;
                    int bookingCode = Int32.Parse(labelBookingCode.Text);

                    BookingCADNS.BookingCAD aux = new BookingCADNS.BookingCAD();
                    aux.deleteBooking(bookingCode);

                    Response.Redirect("Bookings.aspx");
                    break;
            }
        }
    }
}