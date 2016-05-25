// Boys are back in town

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
        private string s = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

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
                DateTime startaux;
                DateTime finishaux;
                Date startDate;
                Date finishDate;

                while (dr.Read()) {  // reads the result of the query

                    //System.Windows.Forms.MessageBox.Show(dr["startDate"].ToString());
                    startaux = (DateTime)dr["startDate"];
                    finishaux = (DateTime)dr["finishDate"];
                    startDate = new Date(startaux.Day, startaux.Month, startaux.Year);
                    finishDate = new Date(finishaux.Day, finishaux.Month, finishaux.Year);

                    // adds the read booking to the array which will be returned at the end of this function
                    BookingEN aux = new BookingEN((int)dr["code"], dr["usr"].ToString(), (int)dr["car"], startDate, finishDate, (bool)dr["driver"], (bool)dr["satNav"], (bool)dr["babyChair"], (bool)dr["childChair"], (bool)dr["baca"], (bool)dr["insurance"], (bool)dr["youngDriver"], (int)dr["pickUp"], (int)dr["delivery"], 100);
                    bookings.Add(aux);
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
            BookingEN booking = new BookingEN();
            SqlDataReader dr = null;

            try {
                conn = new SqlConnection(s);
                conn.Open();
                String query = "SELECT * FROM T_Booking WHERE code = " + code + ";";

                SqlCommand com = new SqlCommand(query, conn);
                dr = com.ExecuteReader();
                DateTime startaux, finishaux;
                Date startDate, finishDate;
                int caraux, pickup, delivery, codeaux;
                string user;
                bool driver, satnav, babychair, childchair, baca, insurance, youngdriver;
                double totalprice;

                // Devuelve Empty
                while (dr.Read())
                {  // if there is some data found
                    startaux = (DateTime)dr["startDate"];
                    finishaux = (DateTime)dr["finishDate"];
                    startDate = new Date(startaux.Day, startaux.Month, startaux.Year);
                    finishDate = new Date(finishaux.Day, finishaux.Month, finishaux.Year);
                    //totalprice = (double)dr["totPrice"];
                    // we return the data found inside an object of type BookingEN

                    booking = new BookingEN(codeaux, dr["usr"].ToString(), caraux, startDate, finishDate, (bool)dr["driver"], (bool)dr["satNav"], (bool)dr["babyChair"], (bool)dr["childChair"], (bool)dr["baca"], (bool)dr["insurance"], (bool)dr["youngDriver"], (int)dr["pickUp"], (int)dr["delivery"], 100);
                }
                return booking;

            } finally {
                if (dr != null)
                    dr.Close();
                if (conn.State == ConnectionState.Open)
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
