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
using OfferENns;
using BookingENns;
// specific namespace for the CAD
namespace OfferCADNS
{
    public class OfferCAD
    {
      // the connection string is specified in the web.config file, this way it acts like a constant
      private string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString ();

      // ENs to be returned in some functions
      private OfferEN offer;
      private ArrayList offers;

      // Connection variable
      private SqlConnection conn;


      // initializes the connection in the constructor
      public OfferCAD() {
        conn = new SqlConnection(s);
      }

      // returns an arraylist with all the offers stored in the DataBase
      public ArrayList getAllOffers() {
        try {
          offers = new ArrayList();
          conn.Open();
          SqlCommand query = new SqlCommand("SELECT * FROM T_Offer", conn);
          SqlDataReader dr = query.ExecuteReader();
          // loop for reading all the records
          while (dr.Read()) {
              int[] date = new int[3];
              String startDate = dr["startDate"].ToString();
              int j = 0;
              for (int i = 0; i < startDate.Length; i++)
              {
                  String s = "";
                  while (startDate[i] != '-')
                  {
                      s += startDate[i];
                  }
                  date[j] = int.Parse(s);
                  j++;
              }
              Date sd = new Date(date[0], date[1], date[2]);

              date = new int[3];
              String finishDate = dr["finishDate"].ToString();
              j = 0;
              for (int i = 0; i < finishDate.Length; i++)
              {
                  String s = "";
                  while (finishDate[i] != '-')
                  {
                      s += finishDate[i];
                  }
                  date[j] = int.Parse(s);
                  j++;
              }
              Date fd = new Date(date[0], date[1], date[2]);

              // adds to the returning array an offer
                  offers.Add(new OfferEN((int)dr["code"], (int)dr["car"], sd, fd, dr["IMG"].ToString(), (double)dr["newPrice"], dr["title"].ToString(), dr["description"].ToString()));
          }

          dr.Close();

          return offers;
        } finally {
          conn.Close();
        }
      }

      // returns a specific offer identified by its code
      public OfferEN getOffer(int code) {
        try {
          conn.Open();
          SqlCommand query = new SqlCommand("SELECT * FROM T_Offer WHERE code=" + code, conn);
          SqlDataReader dr = query.ExecuteReader();

          if (dr.Read()) {  // if an offer is found we create the offer EN
              String startDate = dr["startDate"].ToString();
              int j = 0;
              int[] date = new int[3];
              for (int i = 0; i < startDate.Length; i++)
              {
                  String s = "";
                  while (startDate[i] != '-')
                  {
                      s += startDate[i];
                  }
                  date[j] = int.Parse(s);
                  j++;
              }
              Date sd = new Date(date[0], date[1], date[2]);

              date = new int[3];
              String finishDate = dr["finishDate"].ToString();
              j = 0;
              for (int i = 0; i < finishDate.Length; i++)
              {
                  String s = "";
                  while (finishDate[i] != '-')
                  {
                      s += finishDate[i];
                  }
                  date[j] = int.Parse(s);
                  j++;
              }
              Date fd = new Date(date[0], date[1], date[2]);
            // offer to be returned
            offer = new OfferEN((int)dr["code"],(int)dr["car"],sd,fd,dr["IMG"].ToString(),(double)dr["newPrice"],dr["title"].ToString(),dr["description"].ToString());
          }

          dr.Close();

          return offer;

        } finally {
          conn.Close();
        }
      }

      // updates an existing offer given itself
      public void updateOffer(OfferEN c) {
        try {
          conn.Open();
          SqlCommand sql = new SqlCommand("UPDATE T_Offer SET car=" + c.Car + ", startDate='" + c.StartDate + "', finishDate='" + c.FinishDate + "', IMG='" + c.Img + "', newPrice=" + c.NewPrice + ", title='" + c.Title + "', description='" + c.Description + "' WHERE code=" + c.Code, conn);
          sql.ExecuteNonQuery();
        } finally {
          conn.Close();
        }
      }

      // inserts a new offer into the DataBase given an Offer Business Entity
      public void insertOffer(OfferEN c) {
        try {
          conn.Open();
          SqlCommand sql = new SqlCommand("INSERT INTO T_Offer VALUES (" + c.Car + ", '" + c.StartDate + "', '" + c.FinishDate + "', '" + c.Img + "', " + c.NewPrice + ", '" + c.Title + "', '" + c.Description + " )", conn);
          sql.ExecuteNonQuery();
        } finally {
          conn.Close();
        }
      }

      // deletes an already existing offer given its code as identifier
      public void deleteOffer(int code) {
        try {
          conn.Open();
          SqlCommand sql = new SqlCommand("DELETE FROM T_Offer WHERE code=" + code, conn);
          sql.ExecuteNonQuery();
        } finally {
          conn.Close();
        }
      }


    }
}
