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

namespace OfferCADNS
{
    public class OfferCAD
    {
      private string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString ();
      private OfferEN offer;
      private ArrayList offers;
      private SqlConnection conn;

      public OfferCAD() {
        conn = new SqlConnection(s); // FALTA POR PONER BIEN LO DEL STRING 's' !!
      }

      public ArrayList getAllOffers() {
        try {
          offers = new ArrayList();
          conn.Open();
          SqlCommand query = new SqlCommand("SELECT * FROM T_Offer", conn);
          SqlDataReader dr = query.ExecuteReader();

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


                  offers.Add(new OfferEN((int)dr["code"], (int)dr["car"], sd, fd, dr["IMG"].ToString(), (double)dr["newPrice"], dr["title"].ToString(), dr["description"].ToString()));
          }

          dr.Close();

          return offers;
        } finally {
          conn.Close();
        }
      }

      public OfferEN getOffer(int code) {
        try {
          conn.Open();
          SqlCommand query = new SqlCommand("SELECT * FROM T_Offer WHERE code=" + code, conn);
          SqlDataReader dr = query.ExecuteReader();

          if (dr.Read()) {
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

            offer = new OfferEN((int)dr["code"],(int)dr["car"],sd,fd,dr["IMG"].ToString(),(double)dr["newPrice"],dr["title"].ToString(),dr["description"].ToString());
          }

          dr.Close();

          return offer;

        } finally {
          conn.Close();
        }
      }

      public void updateOffer(OfferEN c) {
        try {
          conn.Open();
          SqlCommand sql = new SqlCommand("UPDATE T_Offer SET car=" + c.Car + ", startDate='" + c.StartDate + "', finishDate='" + c.FinishDate + "', IMG='" + c.Img + "', newPrice=" + c.NewPrice + ", title='" + c.Title + "', description='" + c.Description + "' WHERE code=" + c.Code, conn);
          sql.ExecuteNonQuery();
        } finally {
          conn.Close();
        }
      }

      public void insertOffer(OfferEN c) {
        try {
          conn.Open();
          SqlCommand sql = new SqlCommand("INSERT INTO T_Offer VALUES (" + c.Car + ", '" + c.StartDate + "', '" + c.FinishDate + "', '" + c.Img + "', " + c.NewPrice + ", '" + c.Title + "', '" + c.Description + " )", conn);
          sql.ExecuteNonQuery();
        } finally {
          conn.Close();
        }
      }

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
