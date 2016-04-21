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
    public class BookingCAD
    {
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
            /*
            code int(4),
            user varchar(200) NOT NULL,
            car int(4) NOT NULL,
            startDate date NOT NULL,
            finishDate date,
            driver bool NOT NULL DEFAULT false,
            satNav bool NOT NULL DEFAULT false,
            babyChair bool NOT NULL DEFAULT false,
            childChair bool NOT NULL DEFAULT false,
            baca bool NOT NULL DEFAULT false,
            insurance bool NOT NULL DEFAULT false,
            youngDriver bool NOT NULL DEFAULT false,
            pickUp int(4) NOT NULL,
            delivery int(4),
            totPrice decimal(7,2),
            */
            bookings.Add(new BookingEN(dr["code"],dr["user"],dr["car"],dr["startDate"],dr["finishDate"],dr["driver"],dr["satNav"],dr["babyChair"],dr["childChair"],dr["baca"],dr["insurance"],dr["youngDriver"],dr["pickUp"],dr["delivery"],dr["totPrice"]));
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
            booking = new BookingEN(dr["code"],dr["user"],dr["car"],dr["startDate"],dr["finishDate"],dr["driver"],dr["satNav"],dr["babyChair"],dr["childChair"],dr["baca"],dr["insurance"],dr["youngDriver"],dr["pickUp"],dr["delivery"],dr["totPrice"]);
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
          SqlCommand sql = new SqlCommand("UPDATE T_Booking SET user='" + c.User + "', car=" + c.Car + ", startDate='" + c.Date + "', finishDate='" + c.FinishDate + "', driver=" + c.Driver + ", satNav=" + c.SatNav + ", babyChair=" + c.BabyChair + ", baca=" + c.Baca + ", insurance=" + c.Insurance + ", youngDriver=" + c.YoungDriver + ", pickUp=" + c.PickUp + ", delivery=" + c.Delivery + ", totPrice=" + c.TotPrice + " WHERE code=" + c.Code, conn);
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
