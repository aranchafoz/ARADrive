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
using BookingENns;
using System.Globalization;

namespace BookingCADNS
{
    public class BookingCAD
    {

      public static Date ConvertDate(string text)
        {
            DateTime datetime= DateTime.ParseExact(text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            return new Date(datetime.Day, datetime.Month, datetime.Year);
            
        }
      private string s = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString ();
      private BookingEN booking;
      private ArrayList bookings;
      private SqlConnection conn;

      public BookingCAD() {
        conn = new SqlConnection(s); // FALTA POR PONER BIEN LO DEL STRING 's' !!
      }

      public ArrayList getAllBookings() {
        try {
          bookings = new ArrayList();
          conn.Open();
          SqlCommand query = new SqlCommand("SELECT * FROM T_Booking", conn);
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
            bookings.Add(new BookingEN((int)dr["code"],dr["user"].ToString(),(int)dr["car"],sd,fd,(bool)dr["driver"],(bool)dr["satNav"],(bool)dr["babyChair"],(bool)dr["childChair"],(bool)dr["baca"],(bool)dr["insurance"],(bool)dr["youngDriver"],(int)dr["pickUp"],(int)dr["delivery"],(double)dr["totPrice"]));
          }

          dr.Close();

          return bookings;
        } finally {
          conn.Close();
        }
      }

      public BookingEN getBooking(int code) {
        try {
          conn.Open();
          SqlCommand query = new SqlCommand("SELECT * FROM T_Booking WHERE code=" + code, conn);
          SqlDataReader dr = query.ExecuteReader();

          if (dr.Read()) {
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
            booking = new BookingEN((int)dr["code"],dr["usr"].ToString(),(int)dr["car"],sd,fd,(bool)dr["driver"],(bool)dr["satNav"],(bool)dr["babyChair"],(bool)dr["childChair"],(bool)dr["baca"],(bool)dr["insurance"],(bool)dr["youngDriver"],(int)dr["pickUp"],(int)dr["delivery"],(double)dr["totPrice"]);
          }

          dr.Close();

          return booking;

        } finally {
          conn.Close();
        }
      }

      public void updateBooking(BookingEN c) {
        try {
          conn.Open();
          SqlCommand sql = new SqlCommand("UPDATE T_Booking SET usr='" + c.User + "', car=" + c.Car + ", startDate='" + c.Date + "', finishDate='" + c.FinishDate + "', driver=" + c.Driver + ", satNav=" + c.SatNav + ", babyChair=" + c.BabyChair + ", baca=" + c.Baca + ", insurance=" + c.Insurance + ", youngDriver=" + c.YoungDriver + ", pickUp=" + c.PickUp + ", delivery=" + c.Delivery + ", totPrice=" + c.TotPrice + " WHERE code=" + c.Code, conn);
          sql.ExecuteNonQuery();
        } finally {
          conn.Close();
        }
      }

      public void insertBooking(BookingEN c) {
        try {
          conn.Open();
          SqlCommand sql = new SqlCommand("INSERT INTO T_Booking VALUES (" + c.Code + ", '" + c.User + "', " + c.Car + ", '" + c.Date + "', '" + c.FinishDate + "', " + c.Driver + ", " + c.SatNav + ", " + c.BabyChair + ", " + c.Baca + ", " + c.Insurance + ", " + c.YoungDriver + ", " + c.PickUp + ", " + c.Delivery + ", " + c.TotPrice + " )", conn);
          sql.ExecuteNonQuery();
        } finally {
          conn.Close();
        }
      }

      public void deleteBooking(int code) {
        try {
          conn.Open();
          SqlCommand sql = new SqlCommand("DELETE FROM T_Booking WHERE code=" + code, conn);
          sql.ExecuteNonQuery();
        } finally {
          conn.Close();
        }
      }


    }
}
