// v2.0

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
using System.Globalization;
using BookingENns;
// Namespace specific for this CAD
namespace BookingCADNS
{
    public class BookingCAD
    {
        // the connection string is specified in the web.config file, this way it acts like a constant
        private string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString ();

        // ENs to be returned in some functions
        private BookingEN booking;
        private ArrayList bookings;

        // Connection variable
        private SqlConnection conn;


        // computes the difference in days between two given dates
        public static double DayDifference(Date date1, Date date2)
        {
            DateTime dateTime1 = new DateTime(date1.GetYear(), date1.GetMonth(), date1.GetDay());
            DateTime dateTime2 = new DateTime(date2.GetYear(), date2.GetMonth(), date2.GetDay());
            return (dateTime1 - dateTime2).TotalDays;
        }

        // constructor in which we initialize the connection
        public BookingCAD() {
            conn = new SqlConnection(s);
        }

        // getter for all the bookings
        public ArrayList getAllBookings() {
            try {
                bookings = new ArrayList();
                conn.Open();  // opens the connection
                SqlCommand query = new SqlCommand("SELECT * FROM T_Booking", conn); // prepares the query
                SqlDataReader dr = query.ExecuteReader(); // executes the query

                while (dr.Read()) {  // reads the result of the query
                            
                    Date sd = fromDateTimeStringtoDate(dr["startDate"].ToString());
                    Date fd = fromDateTimeStringtoDate(dr["finishDate"].ToString());
              
                    // adds the read booking to the array which will be returned at the end of this function
                    bookings.Add(new BookingEN((int)dr["code"],dr["usr"].ToString(),(int)dr["car"],sd,fd,(bool)dr["driver"],(bool)dr["satNav"],(bool)dr["babyChair"],(bool)dr["childChair"],(bool)dr["baca"],(bool)dr["insurance"],(bool)dr["youngDriver"],(int)dr["pickUp"],(int)dr["delivery"],(double)dr["totPrice"]));
                }

                dr.Close(); // we close the datareader

                return bookings;
            } finally {
                conn.Close(); // we close the connection
            }
        }

        public int getLastBookingCode()
        {
            int code = 0;
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT max(code) codigo FROM T_Booking", conn);
                SqlDataReader dr = query.ExecuteReader();

                if (dr.Read())
                {
                    string aux = dr["codigo"].ToString();
                    if (aux != "")
                        code = (Int32)dr["codigo"];
                    else
                        code = 0;
                }

                dr.Close();

                return code;

            }
            finally
            {
                conn.Close();
            }
        }

        // gets a specific booking given its code
        public BookingEN getBooking(int code) {
            try {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT * FROM T_Booking WHERE code=" + code, conn);
                SqlDataReader dr = query.ExecuteReader();

                if (dr.Read()) {  // if there is some data found
                    Date sd = fromDateTimeStringtoDate(dr["startDate"].ToString());
                    Date fd = fromDateTimeStringtoDate(dr["finishDate"].ToString());

                    // we return the data found inside an object of type BookingEN
                    booking = new BookingEN((int)dr["code"],dr["usr"].ToString(),(int)dr["car"],sd,fd,(bool)dr["driver"],(bool)dr["satNav"],(bool)dr["babyChair"],(bool)dr["childChair"],(bool)dr["baca"],(bool)dr["insurance"],(bool)dr["youngDriver"],(int)dr["pickUp"],(int)dr["delivery"],(double)dr["totPrice"]);
                }

                dr.Close();

                return booking;

            } finally {
                conn.Close();
            }
        }

        // Changes an already existing booking given itself
        public void updateBooking(BookingEN c) {
            try {
                conn.Open();

                int satNav = fromBooltoInt(c.SatNav);
                int babyChair = fromBooltoInt(c.BabyChair);
                int baca = fromBooltoInt(c.Baca);
                int insurance = fromBooltoInt(c.Insurance);
                int youngDriver = fromBooltoInt(c.YoungDriver);

                SqlCommand sql = new SqlCommand("UPDATE T_Booking SET usr='" + c.User + "', car=" + c.Car + ", startDate='" + c.Date + "', finishDate='" + c.FinishDate + "', driver=" + c.Driver + ", satNav=" + satNav + ", babyChair=" + babyChair + ", baca=" + baca + ", insurance=" + insurance + ", youngDriver=" + youngDriver + ", pickUp=" + c.PickUp + ", delivery=" + c.Delivery + ", totPrice=" + c.TotPrice + " WHERE code=" + c.Code, conn);
                sql.ExecuteNonQuery();
            } finally {
                conn.Close();
            }
        }

        // creates a new booking
        public void insertBooking(BookingEN c) {
            
            try {
                conn.Open();
                int code = c.Code;
                int driver = fromBooltoInt(c.Driver);
                int satNav = fromBooltoInt(c.SatNav);
                int babyChair = fromBooltoInt(c.BabyChair);
                int childChair = fromBooltoInt(c.ChildChair);
                int baca = fromBooltoInt(c.Baca);
                int insurance = fromBooltoInt(c.Insurance);
                int youngDriver = fromBooltoInt(c.YoungDriver);
                string startDate = c.Date.DateToString_YearMonthDay();
                string finishDate = c.Date.DateToString_YearMonthDay();

                SqlCommand sql = new SqlCommand("INSERT INTO T_Booking VALUES (" + code + ",'" + c.User + "'," + c.Car + ",'" + startDate + "','" + finishDate + "'," + driver + "," + satNav + "," + babyChair + "," + childChair + "," + baca + "," + insurance + "," + youngDriver + "," + c.PickUp + "," + c.Delivery + "," + c.TotPrice + ")", conn);
                sql.ExecuteNonQuery();
            } finally {
                conn.Close();
            }
        }

        // deletes/cancels an already existing booking given its code
        public void deleteBooking(int code) {
            try {
                conn.Open();
                SqlCommand sql = new SqlCommand("DELETE FROM T_Booking WHERE code=" + code, conn);
                sql.ExecuteNonQuery();
            } finally {
                conn.Close();
            }
        }


        // Conversors
        public Date fromDateTimeStringtoDate(String fecha)
        {
            int[] date = new int[3];
            String datetime = fecha.ToString();
            int j = 0;
            for (int i = 0; i < datetime.Length; i++)
            {
                String s = "";
                while (datetime[i] != '-')
                {
                    s += datetime[i];
                }
                date[j] = int.Parse(s);
                j++;
            }
            Date output = new Date(date[0], date[1], date[2]);

            return output;
        }

        // this function converts a given string formatted like an MySQL date to a Date object
        public static Date ConvertDate(string text)
        {
            DateTime datetime = DateTime.ParseExact(text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            return new Date(datetime.Day, datetime.Month, datetime.Year);
        }

        public int fromBooltoInt(bool a)
        {
            int output = 0;
            if (a == true) output = 1;
            return output;
        }

    }
}
