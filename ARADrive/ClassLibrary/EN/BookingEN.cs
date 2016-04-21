using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Class1
/// </summary>
/// 
namespace ARADrive{
    public class Fecha{
        private int dia;
        private int mes;

        public int GetDia(){
            return dia;
        }

        public int GetMes(){
            return mes;
        }
    }

    public class BookingEN{

        private int code;
        private string name;
        private Fecha startDate;
        private Fecha finishDate;
        private bool driver;
        private bool satNav;
        private bool babyChair;
        private bool childChair;
        private bool baca;
        private bool insurance;
        private bool youngDriver;
        private string pickUp;
        private int delivery;
        private int totPrice;

        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Fecha StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public Fecha FinishDate
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

        public string PickUp
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

        public BookingEN(int code, string name, Fecha inicio, Fecha fin, bool driver, bool satNav, bool BChair, bool CChair, bool baca, bool insurance, bool yngdriver, bool pickup, int delivery, float tprice)
        {
            this.code = code;
            this.name = name;
            this.startDate = inicio;
            this.finishDate = fin;
            this.driver = driver;
            this.satNav = satNav;
            this.babyChair = BChair;
            this.childChair = CChair;
            this.baca = baca;
            this.insurance = insurance;
            this.youngDriver = yngDriver;
            this.pickUp = pickup;
            this.delivery = delivery;
            this.totPrice = tprice;
        }


    }


}
