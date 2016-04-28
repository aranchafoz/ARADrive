using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;
using System.Configuration;

namespace CarCADNS
{
    public class CarCAD
    {
      private string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString ();
      private CarEN car;
      private ArrayList cars;
      private SqlConnection conn;

      public CarCAD() {
        conn = new SqlConnection(s); // FALTA POR PONER BIEN LO DEL STRING 's' !!
      }

      public ArrayList getAllCars() {
        try {
          cars = new ArrayList();
          conn.Open();
          SqlCommand query = new SqlCommand("SELECT * FROM T_Car", conn);
          SqlDataReader dr = query.ExecuteReader();

          while (dr.Read()) {
            cars.Add(new CarEN(dr["code"],dr["category"],dr["name"],dr["desc"],dr["price"],dr["automaticTransmission"],dr["doors"],dr["IMG"]));
          }

          dr.Close();

          return cars;
        } finally {
          conn.Close();
        }
      }

      public CarEN getCar(int code) {
        try {
          conn.Open();
          SqlCommand query = new SqlCommand("SELECT * FROM T_Car WHERE code=" + code, conn);
          SqlDataReader dr = query.ExecuteReader();

          if (dr.Read()) {
            car = new CarEN(dr["code"],dr["category"],dr["name"],dr["desc"],dr["price"],dr["automaticTransmission"],dr["doors"],dr["IMG"]);
          }

          dr.Close();

          return car;

        } finally {
          conn.Close();
        }
      }

      public void updateCar(CarEN c) {
        try {
          conn.Open();
          SqlCommand sql = new SqlCommand("UPDATE T_Car SET category=" + c.Category + ", name='" + c.Name + "', desc='" + c.Desc + "', price=" + c.Price + ", automaticTransmission=" + c.AutomaticTransmission + ", doors=" + c.Doors + ", IMG='" + c.
              IMG + "' WHERE code=" + c.Code, conn);
          sql.ExecuteNonQuery();
        } finally {
          conn.Close();
        }
      }

      public void insertCar(CarEN c) {
        try {
          conn.Open();
          SqlCommand sql = new SqlCommand("INSERT INTO T_Car VALUES (" + c.Code + ", " + c.Category + ", '" + c.Name + "', '" + c.Desc + "', " + c.Price + ", " + c.AutomaticTransmission + ", " + c.Doors + ", '" + c.IMG + "')", conn);
          sql.ExecuteNonQuery();
        } finally {
          conn.Close();
        }
      }

      public void deleteCar(int code) {
        try {
          conn.Open();
          SqlCommand sql = new SqlCommand("DELETE FROM T_Car WHERE code=" + code, conn);
          sql.ExecuteNonQuery();
        } finally {
          conn.Close();
        }
      }


    }
}
