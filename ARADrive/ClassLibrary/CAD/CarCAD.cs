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
      private string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString ();
      private CarEN car;
      private SqlConnection conn;

      public CarCAD() {
        conn = new SqlConnection(s);
      }

      public DataSet getAllCars()
      {
        try{
          DataSet bdvirtual = new DataSet();
          SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_Car", conn);
          sql.Fill(bdvirtual,"car");
          return bdvirtual;
        }finally{
          conn.Close();
        }
      }

      public CarEN getCar(int code) {
        try{
            DataSet bdvirtual = new DataSet();
            SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_Car WHERE code=" + code, conn);
            sql.Fill(bdvirtual,"car");
            DataTable t = new DataTable();
            t = bdvirtual.Tables["car"];
            DataRow dr = t.Rows[0];

            //car = new CarEN(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
            car = new CarEN((int)dr[0], (int)dr[1], dr[2].ToString(), dr[3].ToString(), (double)dr[4], (bool)dr[5], (int)dr[6], dr[7].ToString());
            return(car);
        }finally{
          conn.Close();
        }
      }

      public bool updateCar(CarEN c) {
        try{
          DataSet bdvirtual = new DataSet();
          SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_Car WHERE code=" + c.Code, conn);
          sql.Fill(bdvirtual,"car");
          DataTable t = new DataTable();
          t = bdvirtual.Tables["car"];
          DataRow row = t.Rows[0];
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
          sql.Update(bdvirtual, "car");
          return true;
        }catch{
            return false;
        }finally{
          conn.Close();
        }
      }

      public bool insertCar(CarEN c) {
        try{
          DataSet bdvirtual = new DataSet();
          SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_Car", conn);
          sql.Fill(bdvirtual,"car");
          DataTable t = new DataTable();
          t = bdvirtual.Tables["car"];
          DataRow nuevafila = t.NewRow();
          nuevafila[0] = c.Code;
          nuevafila[1] = c.Category;
          nuevafila[2] = c.Name;
          nuevafila[3] = c.Desc;
          nuevafila[4] = c.Price;
          nuevafila[5] = c.AutomaticTransmission;
          nuevafila[6] = c.Doors;
          nuevafila[7] = c.IMG;
          t.Rows.Add(nuevafila);
          SqlCommandBuilder cbuilder = new SqlCommandBuilder(sql);
          sql.Update(bdvirtual, "car");
          return true;
        }catch{
            return false;
        }finally{
          conn.Close();
        }
      }

      public void deleteCar(int code) {
        try{
          DataSet bdvirtual = new DataSet();
          SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_Car WHERE code=" + code, conn);
          sql.Fill(bdvirtual,"car");
          DataTable t = new DataTable();
          t = bdvirtual.Tables["car"];
          t.Rows[0].Delete();
          SqlCommandBuilder cbuilder = new SqlCommandBuilder(sql);
          sql.Update(bdvirtual, "car");
        }finally{
          conn.Close();
        }
      }
    }
}
