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
    public class PaymentMethodCAD {

      private PaymentMethodEN paymentMethod;
      private SqlConnection c;
      private ArrayList allPaymentMethods;

      public PaymentMethodCAD(){
        c = new SqlConnection(s);
      }




      public ArrayList allPaymentMethods(){
        try{
          c.Open();
          allPaymentMethods = new ArrayList();
          SqlCommand com = new SqlCommand("Select * from T_PaymentMethod", c);
          SqlDataReader dr = com.ExecuteReader();

          while(dr.Read()){
            PaymentMethodEN aux = PaymentMethodEN(dr["usr"], dr["pass"], dr["client"]);
            allPaymentMethods.Add(aux);
          }

          dr.Close();
        }finally{
          c.Close();

          return(allPaymentMethods);
        }
      }

      public ENClient getPaymentMethod(String client){
        try{
          c.Open();
          SqlCommand com = new SqlCommand("Select * from T_PaymentMethod WHERE client='"+client+"'", c);
          SqlDataReader dr = com.ExecuteReader();


          ENClient aux = ENClient(dr["usr"], dr["pass"], dr["client"]);

          dr.Close();
        }finally{
          c.Close();

          return(aux);
        }
      }


      public void updatePaymentMethod(PaymentMethodEN pm){
        try{
          c.Open();
          SqlCommand com = new SqlCommand("UPDATE T_PaymentMethod set pass='"+pm.Pass+"', usr='"+pm.User+"'", c);
          com.ExecuteNonQuery();
        }finally{
          c.Close();
        }
      }

      public void deletePaymentMethod(String client){
        try{
          c.Open();
          SqlCommand com = new SqlCommand("DELETE FROM T_PaymentMethod WHERE client='"+client+"'", c);
          com.ExecuteNonQuery();
        }finally{
          c.Close();
        }
      }

      public void insertPaymentMethod(PaymentMethodEN pm){
        try{
          c.Open();
          SqlCommand com = new SqlCommand("INSERT INTO T_PaymentMethod VALUES('"+pm.User+"', '"+pm.Pass+"', '"+pm.Client+"')", c);
          com.ExecuteNonQuery();
        }finally{
          c.Close();
        }
      }
    }
}
