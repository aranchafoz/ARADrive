using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Catalog : System.Web.UI.Page
    {
        int carCode = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowCategory();
        }


        protected void Catalog_ItemDataBound(Object sender, DataListCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "ClickSeeMore":

                    Label labelCarCode = e.Item.FindControl("Label_CarCode") as Label;
                    carCode = Int32.Parse(labelCarCode.Text);

                    Server.Transfer("Product.aspx?code=" + carCode + "&pageOrigin=catalog");
                    Response.Redirect("Product.aspx");
                    break;
            }

        }


        protected void ShowCategory()
        {
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

                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Could not load the data correctly!");

            }
        }
    }
}