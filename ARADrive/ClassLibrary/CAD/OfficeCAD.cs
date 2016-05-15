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

      private string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString ();
      private OfficeEN office;
      private SqlConnection c;
      private ArrayList allOffices;

      public OfficeCAD(){
        c = new SqlConnection(s);
      }




      public ArrayList getAllOffices(){
        try{
          c.Open();
          allOffices = new ArrayList();
          SqlCommand com = new SqlCommand("Select * from T_Office", c);
          SqlDataReader dr = com.ExecuteReader();

          while(dr.Read()){
            OfficeEN aux = new OfficeEN((int)dr["code"], dr["name"].ToString(), dr["address"].ToString(), dr["city"].ToString(), (double)dr["cX"], (double)dr["cY"]);
            allOffices.Add(aux);
          }

          dr.Close();
        }finally{
            c.Close();
        }
        return (allOffices);
      }

      public OfficeEN getOffice(int code){
        try{
          c.Open();
          SqlCommand com = new SqlCommand("Select * from T_Office WHERE code="+code, c);
          SqlDataReader dr = com.ExecuteReader();


          OfficeEN aux = new OfficeEN((int)dr["code"], dr["name"].ToString(), dr["address"].ToString(), dr["city"].ToString(), (double)dr["cX"], (double)dr["cY"]);


          dr.Close();
          return aux;
        }finally{
          c.Close();
        }
      }
    }
}
