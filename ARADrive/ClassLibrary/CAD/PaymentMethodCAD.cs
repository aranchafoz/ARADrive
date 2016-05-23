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
using PaymentMethodENns;
using ClientENns;


namespace PaymentMethodCADNS{
    public class PaymentMethodCAD {

      // Get connection string needed to connect with the data base
      private string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString ();

      // Instance of PaymentMethodEN
      private PaymentMethodEN paymentMethod;

      // We create connection, it will be used for the queries and other data base connections
      private SqlConnection c;

      // Array which will contain a number of PaymentMethods
      private ArrayList allPaymentMethods;

      // Constructor
      public PaymentMethodCAD(){
        c = new SqlConnection(s);
      }



      // Method that gets all the PaymentMethods saved in the data base
      public ArrayList getAllPaymentMethods(){
        try{
          c.Open();
          allPaymentMethods = new ArrayList();

          // First we select all the information about all the PaymentMethods in the data base
          SqlCommand com = new SqlCommand("Select * from T_PaymentMethod", c);
          SqlDataReader dr = com.ExecuteReader();

          while(dr.Read()){
            // Each result is saved into an auxiliary variable
            PaymentMethodEN aux = new PaymentMethodEN(dr["usr"].ToString(), dr["pass"].ToString(), dr["client"].ToString());

            // And then added to the ArrayList
            allPaymentMethods.Add(aux);
          }

          dr.Close();
        }finally{
          c.Close();
        }
        return (allPaymentMethods);
      }


        // Method that gets a concrete PaymentMethod identified by the client's identifier
        public PaymentMethodEN getPaymentMethod(String client)
        {
            PaymentMethodEN aux = new PaymentMethodEN();
            try{
                c.Open();

                // First we select all the information about the paymentMethod identified by the client idetificator passed as a parameter
                SqlCommand com = new SqlCommand("Select * from T_PaymentMethod WHERE client='"+client+"'", c);
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    // The result is saved into a PaymentMethodEN instance which will be returned later
                    aux = new PaymentMethodEN(dr["usr"].ToString(), dr["pass"].ToString(), dr["client"].ToString());
                }
                dr.Close();
                return (aux);
            }
            finally {
                c.Close();
            }
        }


      // Method that updated a PaymentMethod from the information of a PaymentMethodEN
      public void updatePaymentMethod(PaymentMethodEN pm){
        try{
          c.Open();

          // This is the SQL sentence used to update the PaymentMethod, the information comes from the passed parameter
          SqlCommand com = new SqlCommand("UPDATE T_PaymentMethod set pass='"+pm.Pass+"', usr='"+pm.User+"'", c);
          com.ExecuteNonQuery();
        }finally{
          c.Close();
        }
      }


      // Method used to delete a PaymentMethod identified by a client's identifier
      public void deletePaymentMethod(String client){
            try {
                c.Open();

                // This is the SQL sentence used to delete a PaymentMethod identified by the information in the passes paramater
                SqlCommand com = new SqlCommand("DELETE FROM T_PaymentMethod WHERE client='" + client + "'", c);
                com.ExecuteNonQuery();
            }catch (SqlException e) { 

            System.Windows.Forms.MessageBox.Show("Email not valid.");
        
    }finally{
          c.Close();
        }
      }


      // Method that inserts a new PaymentMethod
      public void insertPaymentMethod(PaymentMethodEN pm){
        try{
          c.Open();

          // This is the SQL sentence used to insert a new PaymentMethod with the information provided in the passes parameter (a PaymentMethodEN)
          SqlCommand com = new SqlCommand("INSERT INTO T_PaymentMethod VALUES('"+pm.User+"', '"+pm.Pass+"', '"+pm.Client+"')", c);
          com.ExecuteNonQuery();
        }
        finally {
          c.Close();
        }
      }
    }
}
