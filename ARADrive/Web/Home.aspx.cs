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
        private DateTime date_PickUp;
        private DateTime date_DropOff;

        protected void Page_Load(object sender, EventArgs e)
        {
            Button_Search.Click += new EventHandler(this.OnClick_Search);
        }
        
        protected void OnClick_Search(Object sender, EventArgs e)
        {

            if ((Calendar_PickUp.SelectedDate > DateTime.Today) && (Calendar_PickUp.SelectedDate > DateTime.Today))
            {
                // Read Pick Up Date and Drop Off Date
                if (Calendar_PickUp.SelectedDate <= Calendar_DropOff.SelectedDate)  // HERE: Check if some date is selected
                {
                    date_PickUp = Calendar_PickUp.SelectedDate;
                    date_DropOff = Calendar_DropOff.SelectedDate;
                    ShowResult();
                }
                else
                {
                    //System.Windows.Forms.MessageBox.Show("Please select the Pick Up Date before the Drop Off Date");
                }
            }
            else
            {
                //System.Windows.Forms.MessageBox.Show("The dates cannot be before today!");
            }

        }


        protected void ShowResult()
        {

            Line1.Visible = true;
            Label_Result.Text = "Selected Date: From " + date_PickUp.Day.ToString() + "."
                                    + date_PickUp.Month.ToString() + "." + date_PickUp.Year.ToString()
                                    + " until " + date_DropOff.Day.ToString() + "."
                                    + date_DropOff.Month.ToString() + "." + date_DropOff.Year.ToString();
            Label_Result.Visible = true;

        }
    }
}