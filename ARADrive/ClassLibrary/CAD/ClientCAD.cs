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
        ClientEN aux;
        try
        {
                c = new SqlConnection(s);
                c.Open();
                String query = "SELECT * FROM T_User WHERE email='" + email + "';";

            SqlCommand com = new SqlCommand(query, c);
            SqlDataReader dr = com.ExecuteReader();
                dr.Read();
            // Date cast
            int[] date = new int[3];
            string startDate = dr["birthDate"].ToString();
            int j = 0;
            for (int i = 0; i < startDate.Length; i++)
            {
                String s = "";
                while (startDate[i] != '-')
                {
                    
                }
                date[j] = int.Parse(s);
                j++;
            }
            Date sd = new Date(date[0], date[1], date[2]);

            // Premium cast
            bool premium = false;
            if (dr["premium"].ToString() == (1+"")) premium = true;

            // Driving license cast
            bool license = false;
            if (dr["drivingLicence"].ToString() == (1 + "")) license = true;

            aux = new ClientEN(dr["email"].ToString(), dr["pass"].ToString(), premium, dr["DNI"].ToString(), dr["name"].ToString(), dr["surname"].ToString(), (int)dr["phone"], dr["address"].ToString(), dr["city"].ToString(), sd, license);
                
            dr.Close();
        }finally{
            c.Close();         
        }
        return (aux);
        }


      public void updateClient(ClientEN cl){
        try{
          c.Open();
          SqlCommand com = new SqlCommand("UPDATE T_User set pass='"+cl.Pass+"', premium="+cl.Premium+", DNI='"+cl.DNI+"', name='"+cl.Name+"', surname='"+cl.Surname+"', phone="+cl.Phone+", address='"+cl.Address+"', city='"+cl.City+"', birthDate='"+cl.BirthDate+"', drivingLicence="+cl.DrivingLicence + " WHERE email='"+cl.Email, c);
          com.ExecuteNonQuery();
        }finally{
          c.Close();
        }
      }

      public void deleteClient(String email){
        try{
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
                //string birthdate = cl.BirthDate.GetDay() + "-" + cl.BirthDate.GetMonth() + "-" + cl.BirthDate.GetYear();
                
          c.Open();
          SqlCommand com = new SqlCommand("INSERT INTO T_User VALUES('"+cl.Email+"', '"+cl.Pass+"', "+premium+",'"+cl.DNI+"', '"+cl.Name+"', '"+cl.Surname+"', "+cl.Phone+", '"+cl.Address+"', '"+cl.City+"', '"+cl.BirthDate+"', "+cl.DrivingLicence+")", c);
          com.ExecuteNonQuery();
        }//catch(SqlException e) {}
        finally {
          c.Close();
        }
      }
    }
}
