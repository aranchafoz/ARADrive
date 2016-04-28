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

namespace ARADrive{
    public class OfficeCAD {

      private OfficeEN office;
      private SqlConnection c;
      private ArrayList allOffices;

      public OfficeCAD(){
        c = new SqlConnection(s);
      }




      public ArrayList AllOffices(){
        try{
          c.Open();
          allOffices = new ArrayList();
          SqlCommand com = new SqlCommand("Select * from T_Office", c);
          SqlDataReader dr = com.ExecuteReader();

          while(dr.Read()){
            OfficeEN aux = OfficeEN(dr["code"], dr["name"], dr["address"], dr["city"], dr["cX"], dr["cY"]);
            allOffices.Add(aux);
          }

          dr.Close();
        }finally{
          c.Close();

          return(allOffices);
        }
      }

      public OfficeEN getOffice(int code){
        try{
          c.Open();
          SqlCommand com = new SqlCommand("Select * from T_Office WHERE code="+code, c);
          SqlDataReader dr = com.ExecuteReader();


          OfficeEN aux = OfficeEN(dr["code"], dr["name"], dr["address"], dr["city"], dr["cX"], dr["cY"]);


          dr.Close();
        }finally{
          c.Close();

          return(aux);
        }
      }
    }
}
