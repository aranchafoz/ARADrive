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
using System.Globalization;

namespace ClientCADNS{
    public class ClientCAD {

        private string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        private ClientEN client;
        private SqlConnection c;
        private ArrayList allClients;

        public ClientCAD() {
            c = new SqlConnection(s);
        }

       

      public ArrayList getAllClients(){
        try{
          c.Open();
          allClients = new ArrayList();
          SqlCommand com = new SqlCommand("Select * from T_User", c);
          SqlDataReader dr = com.ExecuteReader();

          while(dr.Read()){
            ClientEN aux = new ClientEN(dr["email"].ToString(), dr["pass"].ToString(), (bool)dr["premium"], dr["DNI"].ToString(), dr["name"].ToString(), dr["surname"].ToString(), (int)dr["phone"], dr["address"].ToString(), dr["city"].ToString(), (Date)dr["birthDate"], (bool)dr["drivingLicence"]);
            allClients.Add(aux);
          }

          dr.Close();
        }finally{
          c.Close();

          
        }
            return (allClients);
        }

      public ClientEN getClient(String email){
        ClientEN aux = new ClientEN();
        try
        {
                c = new SqlConnection(s);
                c.Open();
                String query = "SELECT * FROM T_User WHERE email='" + email + "';";

            SqlCommand com = new SqlCommand(query, c);
            SqlDataReader dr = com.ExecuteReader();

                //string startDate = null;
                DateTime startDate = DateTime.MinValue; ;
                while (dr.Read())
                {
                    // Date cast
                    // int[] date = new int[3];
                    startDate = (DateTime)dr["birthDate"];//.ToString();
                                                          //DateTime birth = (DateTime)dr["birthDate"];

                    /*int j = 0;
                        for (int i = 0; i < startDate.Length; i++)
                        {
                            String s = "";
                            if (startDate[i].Equals("-"))
                            {

                            } else { 
                            date[j] = int.Parse(s);
                            j++;
                        }
                    }
                    Date sd = new Date(date[0], date[1], date[2]);*/

                    Date date = new Date(startDate.Day, startDate.Month, startDate.Year); //BookingCADNS.BookingCAD.ConvertDate(startDate);
                                                                                          //DateTime datetime = DateTime.ParseExact(startDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                                                                                          //DateTime birth = new DateTime(date.GetYear(), date.GetMonth(), date.GetDay());

                    bool premium = false;
                    try
                    {
                        if ((dr["premium"].ToString()) == (1 + ""))
                        {
                            premium = true;
                        }
                    }
                    catch (Exception)
                    {

                    }




                    // Driving license cast
                    bool license = false;
                    try
                    {
                        if (dr["drivingLicence"].ToString() == (1 + "")) license = true;
                    }
                    catch
                    {

                    }


                    aux = new ClientEN(dr["email"].ToString(), dr["pass"].ToString(), premium, dr["DNI"].ToString(), dr["name"].ToString(), dr["surname"].ToString(), (int)dr["phone"], dr["address"].ToString(), dr["city"].ToString(), date, license);
                }
            dr.Close();
        }finally{
            c.Close();         
        }
        return (aux);
        }


      public void updateClient(ClientEN cl){
        try{
                c = new SqlConnection(s);
                c.Open();
                DateTime birth = new DateTime(cl.BirthDate.GetYear(), cl.BirthDate.GetMonth(), cl.BirthDate.GetDay());
          SqlCommand com = new SqlCommand("UPDATE T_User set pass='"+cl.Pass+"', premium="+cl.Premium+", DNI='"+cl.DNI+"', name='"+cl.Name+"', surname='"+cl.Surname+"', phone="+cl.Phone+", address='"+cl.Address+"', city='"+cl.City+"', birthDate='"+birth+"', drivingLicence="+cl.DrivingLicence + " WHERE email='"+cl.Email, c);
          com.ExecuteNonQuery();
        }finally{
          c.Close();
        }
      }

      public void deleteClient(String email){
        try{
                c = new SqlConnection(s);
                c.Open();
          SqlCommand com = new SqlCommand("DELETE FROM T_User WHERE email='"+email+"'", c);
          com.ExecuteNonQuery();
        }finally{
          c.Close();
        }
      }

      public void insertCliente(ClientEN cl){
        try{    
                int premium = 0;
                if (cl.Premium == true) premium = 1;
                int license = 0;
                if (cl.DrivingLicence == true) license = 1;
                //Date birthda = BookingCADNS.BookingCAD.ConvertDate(cl.BirthDate.ToString());
                DateTime birthdate = new DateTime(cl.BirthDate.GetYear(), cl.BirthDate.GetMonth(), cl.BirthDate.GetDay());
                //string birthdate = cl.BirthDate.GetDay() + "-" + cl.BirthDate.GetMonth() + "-" + cl.BirthDate.GetYear();
                c = new SqlConnection(s);
                c.Open();
          SqlCommand com = new SqlCommand("INSERT INTO T_User VALUES('"+cl.Email+"', '"+cl.Pass+"', "+premium+",'"+cl.DNI+"', '"+cl.Name+"', '"+cl.Surname+"', "+cl.Phone+", '"+cl.Address+"', '"+cl.City+"', '"+birthdate+"', "+license+")", c);
          com.ExecuteNonQuery();
        }//catch(SqlException e) {}
        finally {
          c.Close();
        }
      }
    }
}
