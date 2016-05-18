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
using OfficeENns;

namespace OfficeCADNS{
    public class OfficeCAD {

      // Get connection string needed to connect with the data base
      private string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString ();

      // Instance of OfficeEN
      private OfficeEN office;

      // We create connection, it will be used for the queries and other data base connections
      private SqlConnection c;

      // We create an array that will contain a number of offices
      private ArrayList allOffices;

      // Constructor
      public OfficeCAD(){
        c = new SqlConnection(s);
      }



      // Method that gets all the offices saved in the data base
      public ArrayList getAllOffices(){
        try{
          c.Open();
          allOffices = new ArrayList();

          // This is the SQL query used to gat all the information about all the offices
          SqlCommand com = new SqlCommand("Select * from T_Office", c);
          SqlDataReader dr = com.ExecuteReader();

          while(dr.Read()){

            // Each result is saved into this auxiliar variable
            OfficeEN aux = new OfficeEN((int)dr["code"], dr["name"].ToString(), dr["address"].ToString(), dr["city"].ToString(), (double)dr["cX"], (double)dr["cY"]);

            // And then added to the ArrayList
            allOffices.Add(aux);
          }

          dr.Close();
        }finally{
            c.Close();
        }
        return (allOffices);
      }

      // Method that gets a concrete office identified by its code
      public OfficeEN getOffice(int code){
        try{
          c.Open();

          // First we select all the information from the office identified by the code passes as a parameter
          SqlCommand com = new SqlCommand("Select * from T_Office WHERE code="+code, c);
          SqlDataReader dr = com.ExecuteReader();

          // The result if used to instantiate a OfficeEN variable with will be returned
          OfficeEN aux = new OfficeEN((int)dr["code"], dr["name"].ToString(), dr["address"].ToString(), dr["city"].ToString(), (double)dr["cX"], (double)dr["cY"]);


          dr.Close();
          return aux;
        }finally{
          c.Close();
        }
      }
    }
}
