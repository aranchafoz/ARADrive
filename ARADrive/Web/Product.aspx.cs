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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params.AllKeys.Contains("code") && Request.Params.AllKeys.Contains("pageOrigin"))
            {
                if (Request.Params["pageOrigin"].Equals("catalog"))
                {
                    carCode = Int32.Parse(Request.Params["code"]);
                    LoadData_PageCatalog(carCode);
                }

            }
        }

        protected void LoadData_PageCatalog(int carCode)
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
            Text_PickUp.Text = "";
            Text_DropOff.Text = "";
            Label_TotalPrice.Text = "-";
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
                result = "Enterprice Vehicle";

            return result;
        }

    }
}
          