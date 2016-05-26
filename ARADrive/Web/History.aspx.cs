using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using ClientENns;
using BookingENns;
using BookingCADNS;
using System.Collections;

namespace Web
{
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is logged, in other case it's redirect to home
            if (Session["user"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            ShowHistory();
        }

        protected void ShowHistory()
        {
            // Loading client of user logged
            ClientEN client = new ClientEN((ClientEN)Session["user"]);

            try
            {
                foreach (DataListItem item in DataListBookings.Items)
                {
                    Label label_code = item.FindControl("Label_BookingCode") as Label;
                    int code = Int32.Parse(label_code.Text.ToString());

                    BookingCAD aux = new BookingCAD();
                    BookingEN booking = aux.getBooking(code);

                    Label label_user = item.FindControl("Label_User") as Label;
                    string user = label_user.Text.ToString();
                    if (user.Equals(client.Email))
                    {
                        item.FindControl("PanelItem").Visible = true;

                        if (booking.Driver)
                        {
                            Image driver = item.FindControl("Image_Driver") as Image;
                            driver.ImageUrl = "assets/img/Checkmark-15.png";
                        }
                        if (booking.SatNav)
                        {
                            Image satNav = item.FindControl("Image_satNav") as Image;
                            satNav.ImageUrl = "assets/img/Checkmark-15.png";
                        }
                        if (booking.Baca)
                        {
                            Image baca = item.FindControl("Image_Baca") as Image;
                            baca.ImageUrl = "assets/img/Checkmark-15.png";
                        }
                        if (booking.Insurance)
                        {
                            Image insurance = item.FindControl("Image_Insurance") as Image;
                            insurance.ImageUrl = "assets/img/Checkmark-15.png";
                        }
                        if (booking.BabyChair)
                        {
                            Image babyChair = item.FindControl("Image_BabyChair") as Image;
                            babyChair.ImageUrl = "assets/img/Checkmark-15.png";
                        }
                        if (booking.ChildChair)
                        {
                            Image childChair = item.FindControl("Image_ChildChair") as Image;
                            childChair.ImageUrl = "assets/img/Checkmark-15.png";
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Could not load the data correctly!");

            }
        }
    }
}