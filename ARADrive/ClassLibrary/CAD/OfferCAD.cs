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

namespace ARADrive
{
    public class OfferCAD
    {
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
            /*
            `code` int(2),
            `car` int(4) NOT NULL,
            `startDate` date NOT NULL,
            `finishDate` date NOT NULL,
            `IMG` varchar(200),
            `newPrice` decimal(7,2) NOT NULL,
            `title` varchar(20) NOT NULL,
            `description` varchar(100) DEFAULT NULL,
            */
            offers.Add(new OfferEN(dr["code"],dr["car"],dr["startDate"],dr["finishDate"],dr["IMG"],dr["newPrice"],dr["title"],dr["description"]));
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
            offer = new OfferEN(dr["code"],dr["car"],dr["startDate"],dr["finishDate"],dr["IMG"],dr["newPrice"],dr["title"],dr["description"]);
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
          SqlCommand sql = new SqlCommand("UPDATE T_Offer SET car=" + c.Car + ", startDate='" + c.Date + "', finishDate='" + c.FinishDate + "', IMG='" + c.IMG + "', newPrice=" + c.NewPrice + ", title='" + c.Title + "', description='" + c.Description + "' WHERE code=" + c.Code, conn);
          sql.ExecuteNonQuery();
        } finally {
          conn.Close();
        }
      }

      public void insertOffer(OfferEN c) {
        try {
          conn.Open();
          SqlCommand sql = new SqlCommand("INSERT INTO T_Offer VALUES (" + c.Car + ", '" + c.Date + "', '" + c.FinishDate + "', '" + c.IMG + "', " + c.NewPrice + ", '" + c.Title + "', '" + c.Description + " )", conn);
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
