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
using CarENns;

namespace CarCADNS
{
    public class CarCAD
    {
      // Get connection string needed to connect with the data base
      private string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString ();

      // Instance of CarEN
      private CarEN car;

      // We create connection, it will be used for the queries and other data base connections
      private SqlConnection conn;

      // Constructor
      public CarCAD() {
        conn = new SqlConnection(s);
      }

      // Method that gets all the cars and all their data from the data base
      public DataSet getAllCars()
      {
        try{
          DataSet bdvirtual = new DataSet();
          // Query which selects everything from the T_Car table
          SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_Car", conn);
          // The information is updated with the data base
          sql.Fill(bdvirtual,"car");
          return bdvirtual;
        }finally{
          conn.Close();
        }
      }

      // Method that gets a especific car from the data base identified by its code
      public CarEN getCar(int code) {
        try{
            DataSet bdvirtual = new DataSet();
            // Query needed to get all the information about the desired car
            SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_Car WHERE code=" + code, conn);
            sql.Fill(bdvirtual,"car");
            DataTable t = new DataTable();
            t = bdvirtual.Tables["car"];
            DataRow dr = t.Rows[0];

            //car = new CarEN(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
            // An instance of type CarEN is created from the information retrieved from the data base
            car = new CarEN((int)dr[0], (int)dr[1], dr[2].ToString(), dr[3].ToString(), (double)dr[4], (bool)dr[5], (int)dr[6], dr[7].ToString());
            return(car);
        }finally{
          conn.Close();
        }
      }

      // Method that updated the information of an especific car from an instante of type CarEN
      public bool updateCar(CarEN c) {
        try{
          DataSet bdvirtual = new DataSet();

          // First the car is retrieved from the data base using this query using the car's code
          SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_Car WHERE code=" + c.Code, conn);
          sql.Fill(bdvirtual,"car");
          DataTable t = new DataTable();
          t = bdvirtual.Tables["car"];
          DataRow row = t.Rows[0];
          // The information is substituted by the information saved in the CarEN
          row[0] = c.Code;
          row[1] = c.Category;
          row[2] = c.Name;
          row[3] = c.Desc;
          row[4] = c.Price;
          row[5] = c.AutomaticTransmission;
          row[6] = c.Doors;
          row[7] = c.IMG;
          t.Rows.Add(row);
          SqlCommandBuilder cbuilder = new SqlCommandBuilder(sql);

          // The information is updated with the data base
          sql.Update(bdvirtual, "car");
          return true;
        }catch{
            return false;
        }finally{
          conn.Close();
        }
      }

      // This method inserts a new car into the data base using the information of a CarEN
      public bool insertCar(CarEN c) {
        try{
          DataSet bdvirtual = new DataSet();
          // First, all the cars are retrieved from the data base
          SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_Car", conn);
          sql.Fill(bdvirtual,"car");
          DataTable t = new DataTable();
          t = bdvirtual.Tables["car"];
          // A new row is creted (for the new car)
          DataRow nuevafila = t.NewRow();

          // The row is modified with the information saven in the CarEN instance
          nuevafila[0] = c.Code;
          nuevafila[1] = c.Category;
          nuevafila[2] = c.Name;
          nuevafila[3] = c.Desc;
          nuevafila[4] = c.Price;
          nuevafila[5] = c.AutomaticTransmission;
          nuevafila[6] = c.Doors;
          nuevafila[7] = c.IMG;

          // The row is added to the rest of rows
          t.Rows.Add(nuevafila);
          SqlCommandBuilder cbuilder = new SqlCommandBuilder(sql);
          // The information is updated with the data base
          sql.Update(bdvirtual, "car");
          return true;
        }catch{
            return false;
        }finally{
          conn.Close();
        }
      }


      // A method that deletes a concrete car identified by its code
      public void deleteCar(int code) {
        try{
          DataSet bdvirtual = new DataSet();

          // First we get the car identified by the code passes as a parameter
          SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_Car WHERE code=" + code, conn);
          sql.Fill(bdvirtual,"car");
          DataTable t = new DataTable();
          t = bdvirtual.Tables["car"];

          // Then we deleted that car
          t.Rows[0].Delete();
          SqlCommandBuilder cbuilder = new SqlCommandBuilder(sql);
          // The information is updated with the data base
          sql.Update(bdvirtual, "car");
        }finally{
          conn.Close();
        }
      }
    }
}
