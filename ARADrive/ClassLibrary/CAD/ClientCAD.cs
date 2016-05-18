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

      private string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString ();
      private ClientEN client;
      private SqlConnection c;
      private ArrayList allClients;

      public ClientCAD(){
        c = new SqlConnection(s);
      }




      public ArrayList getAllClients(){
        try{
          c.Open();
          allClients = new ArrayList();
          SqlCommand com = new SqlCommand("Select * from T_User", c);
          SqlDataReader dr = com.ExecuteReader();

          while(dr.Read()){
            ClientEN aux = new ClientEN(dr["email"], dr["pass"], dr["premium"], dr["DNI"], dr["name"], dr["surname"], dr["phone"], dr["address"], dr["city"], dr["birthDate"], dr["drivingLicence"]);
            allClients.Add(aux);
          }

          dr.Close();
        }finally{
          c.Close();

          return(allClients);
        }
      }

      public ClientEN getClient(String email){
        try{
          c.Open();
          SqlCommand com = new SqlCommand("Select * from T_User WHERE email='"+email+"'", c);
          SqlDataReader dr = com.ExecuteReader();


          ClientEN aux = new ClientEN(dr["email"], dr["pass"], dr["premium"], dr["DNI"], dr["name"], dr["surname"], dr["phone"], dr["address"], dr["city"], dr["birthDate"], dr["drivingLicence"]);


          dr.Close();
        }finally{
          c.Close();

          return(aux);
        }
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
          c.Open();
          SqlCommand com = new SqlCommand("INSERT INTO T_User VALUES('"+cl.Email+"', '"+cl.Pass+"', "+cl.Premium+",'"+cl.DNI+"', '"+cl.Name+"', '"+cl.Surname+"', "+cl.Phone+", '"+cl.Address+"', '"+cl.City+"', '"+cl.BirthDate+"', "+cl.DrivingLicence+")", c);
          com.ExecuteNonQuery();
        }finally{
          c.Close();
        }
      }
    }
}
