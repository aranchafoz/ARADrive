using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookingENns;


/// <summary>
/// Clase 
/// </summary>
namespace OfferENns
{
    public class OfferEN
    {
        private int code;
        private int car;
        private Date startDate;
        private Date finishDate;
        private string img;
        private double newPrice;
        private string title;
        private string description;

        public OfferEN(int code, int car, Date fecha1 , Date Fecha2, string image, double price, string title, string descripcion)
        {
            this.code = code;
            this.car = car;
            this.startDate = fecha1;
            this.finishDate = Fecha2;
            this.img = image;
            this.newPrice = price;
            this.title = title;
            this.description = descripcion;

        }

        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        public int Car
        {
            get { return car; }
            set { car = value; }
        }

        public Date StartDate
        {
            get { return startDate; }
            set { startDate = value; } 
        }

        public Date FinishDate
        {
            get { return finishDate; }
            set { finishDate = value; }
        }

        public string Img
        {
            get { return img; }
            set { img = value; }
        }

        public double NewPrice
        {
            get { return newPrice; }
            set { newPrice = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}

