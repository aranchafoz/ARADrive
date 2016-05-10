using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeENns
{
    public class OfficeEN
    {

        private int code;
        private string name;
        private string address;
        private string city;
        private double cX;
        private double cY;


        public OfficeEN(int code, string name, string address, string city, double cX, double cY)
        {
            this.code = code;
            this.name = name;
            this.address = address;
            this.city = city;
            this.cX = cX;
            this.cY = cY;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        public double CX
        {
            get { return cX; }
            set { cX = value; }
        }

        public double CY
        {
            get { return cY; }
            set { cY = value; }
        }


    }
}