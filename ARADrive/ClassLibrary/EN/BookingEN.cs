using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarENns;


namespace BookingENns{
    public class Date{
        private int day;
        private int month;
        private int year;


        public int GetDay()
        {
            return day;
        }

        public int GetMonth()
        {
            return month;
        }
        

        public int GetYear()
        {
            return year;
        }
    }

    public class BookingEN
    {

        private int code;

        private CarEN car;
        private string user;
        private Date date;

        private Date finishDate;
        private bool driver;
        private bool satNav;
        private bool babyChair;
        private bool childChair;
        private bool baca;
        private bool insurance;
        private bool youngDriver;
        private int pickUp;
        private int delivery;
        private int totPrice;


        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public Date Date
        {
            get { return date; }
            set { date = value; }
        }

        public CarEN Car
        {
            get { return car; }
            set { car = value; }
        }

        public Date FinishDate
        {
            get { return finishDate; }
            set { finishDate = value; }
        }

        public bool Driver
        {
            get { return driver; }
            set { driver = value; }
        }

        public bool SatNav
        {
            get { return satNav; }
            set { satNav = value; }
        }

        public bool BabyChair
        {
            get { return babyChair; }
            set { babyChair = value; }
        }

        public bool ChildChair
        {
            get { return childChair; }
            set { childChair = value; }
        }

        public bool Baca
        {
            get { return baca; }
            set { baca = value; }
        }

        public bool Insurance
        {
            get { return insurance; }
            set { insurance = value; }
        }

        public bool YoungDriver
        {
            get { return youngDriver; }
            set { youngDriver = value; }
        }

        public int PickUp
        {
            get { return pickUp; }
            set { pickUp = value; }
        }

        public int Delivery
        {
            get { return delivery; }
            set { delivery = value; }
        }

        public int TotPrice
        {
            get { return totPrice; }
            set { totPrice = value; }
        }

        
        public BookingEN(int code, string name, Date inicio, Date fin, bool driver, bool satNav, bool BChair, bool CChair, bool baca, bool insurance, bool yngdriver, int pickup, int delivery, int tprice)

        {
            this.code = code;
            this.user = name;
            this.Date = inicio;
            this.finishDate = fin;
            this.driver = driver;
            this.satNav = satNav;
            this.babyChair = BChair;
            this.childChair = CChair;
            this.baca = baca;
            this.insurance = insurance;
            this.youngDriver = yngdriver;
            this.pickUp = pickup;
            this.delivery = delivery;
            this.totPrice = tprice;
        }


    }


}
