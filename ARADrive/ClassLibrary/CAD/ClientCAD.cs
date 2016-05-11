using System;
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
using ClientENns;
using BookingENns;

namespace ClientCADNS{
    public class ClientCAD {

      private string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString ();
      private ClientEN client;
      private SqlConnection c;

      public ClientCAD(){
        c = new SqlConnection(s);
      }




      public DataSet getAllClients(){
        try{
          DataSet bdvirtual = new DataSet();
          SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_User", c);
          sql.Fill(bdvirtual,"user");
          return bdvirtual;
        }finally{
          c.Close();
        }
      }

      public ClientEN getClient(String email){
        try{
            DataSet bdvirtual = new DataSet();
            SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_User WHERE email='"+email+"'", c);
            sql.Fill(bdvirtual,"user");
            DataTable t = new DataTable();
            t = bdvirtual.Tables["user"];
            DataRow dr = t.Rows[0];

            int[] date = new int[3];
            String birthDate = dr[9].ToString();
            int j = 0;
            for (int i = 0; i < birthDate.Length; i++)
            {
                String s = "";
                while (birthDate[i] != '-')
                {
                    s += birthDate[i];
                }
                date[j] = int.Parse(s);
                j++;
            }
            Date bd = new Date(date[0], date[1], date[2]);

          ClientEN aux = new ClientEN(dr[0].ToString(), dr[1].ToString(), (bool)dr[2], dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), (int)dr[6], dr[7].ToString(), dr[8].ToString(), bd, (bool)dr[10]);
          return(aux);
        }finally{
          c.Close();
        }
      }


      public bool updateClient(ClientEN cl){
        try{
          DataSet bdvirtual = new DataSet();
          SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_User WHERE email='"+cl.Email+"'", c);
          sql.Fill(bdvirtual,"user");
          DataTable t = new DataTable();
          t = bdvirtual.Tables["user"];
          DataRow nuevafila = t.Rows[0];
          nuevafila[0] = cl.Email;
          nuevafila[1] = cl.Pass;
          nuevafila[2] = cl.Premium;
          nuevafila[3] = cl.DNI;
          nuevafila[4] = cl.Name;
          nuevafila[5] = cl.Surname;
          nuevafila[6] = cl.Phone;
          nuevafila[7] = cl.Address;
          nuevafila[8] = cl.City;
          nuevafila[9] = cl.BirthDate;
          nuevafila[10] = cl.DrivingLicence;
          t.Rows.Add(nuevafila);
          SqlCommandBuilder cbuilder = new SqlCommandBuilder(sql);
          sql.Update(bdvirtual, "user");
          return true;
        }catch (Exception e) {
            return false;
        }finally{
          c.Close();
        }
      }

      public void deleteClient(String email){
        try{
          DataSet bdvirtual = new DataSet();
          SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_User WHERE email='"+email+"'", c);
          sql.Fill(bdvirtual,"user");
          DataTable t = new DataTable();
          t = bdvirtual.Tables["user"];
          t.Rows[0].Delete();
          SqlCommandBuilder cbuilder = new SqlCommandBuilder(sql);
          sql.Update(bdvirtual, "user");
        }finally{
          c.Close();
        }
      }

      public bool insertCliente(ClientEN cl){
        try{
          DataSet bdvirtual = new DataSet();
          SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM T_User", c);
          sql.Fill(bdvirtual,"user");
          DataTable t = new DataTable();
          t = bdvirtual.Tables["user"];
          DataRow nuevafila = t.NewRow();
          nuevafila[0] = cl.Email;
          nuevafila[1] = cl.Pass;
          nuevafila[2] = cl.Premium;
          nuevafila[3] = cl.DNI;
          nuevafila[4] = cl.Name;
          nuevafila[5] = cl.Surname;
          nuevafila[6] = cl.Phone;
          nuevafila[7] = cl.Address;
          nuevafila[8] = cl.City;
          nuevafila[9] = cl.BirthDate;
          nuevafila[10] = cl.DrivingLicence;
          t.Rows.Add(nuevafila);
          SqlCommandBuilder cbuilder = new SqlCommandBuilder(sql);
          sql.Update(bdvirtual, "user");
          return true;
        }catch (Exception e) {
            return false;
        }finally{
          c.Close();
        }
      }

        
    }
}
