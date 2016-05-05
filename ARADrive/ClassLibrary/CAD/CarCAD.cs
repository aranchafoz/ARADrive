﻿using System.Collections.Generic;
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
      private SqlConnection conn;

      public CarCAD() {
        conn = new SqlConnection(s);
      }

      public ArrayList getAllCars() {
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

            car = new CarEN(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
            return(car);
        }finally{
          c.Close();
        }
      }

      public void updateCar(CarEN c) {
<<<<<<< Updated upstream
        try {
          conn.Open();
          SqlCommand sql = new SqlCommand("UPDATE T_Car SET category=" + c.Category + ", name='" + c.Name + "', desc='" + c.Desc + "', price=" + c.Price + ", automaticTransmission=" + c.AutomaticTransmission + ", doors=" + c.Doors + ", IMG='" + c.
              IMG + "' WHERE code=" + c.Code, conn);
          sql.ExecuteNonQuery();
        } finally {
          conn.Close();
=======
        try{
          DataSet bdvirtual = new DataSet();
          SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_Car WHERE code=" + code, conn);
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
        }catch (Exception e) {
            return false;
        }finally{
          c.Close();
>>>>>>> Stashed changes
        }
      }

      public void insertCar(CarEN c) {
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
        }catch (Exception e) {
            return false;
        }finally{
          c.Close();
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
          c.Close();
        }
      }
    }
}
