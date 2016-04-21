﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Clase 
/// </summary>
namespace ARADrive
{
    public class Offer
    {
        private int code;
        private int car;
        private Fecha startDate;
        private Fecha finishDate;
        private string img;
        private float newPrice;
        private string title;
        private string description;

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

        public string Img
        {
            get { return img; }
            set { img = value; }
        }

        public float NewPrice
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

