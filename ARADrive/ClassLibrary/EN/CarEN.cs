using System;

namespace CarENns
{
    public class CarEN
    {

        // Attributes
        private int code;
        private int category;
        private string name;
        private string desc;
        private double price;
        private bool automaticTransmission;
        private int doors;
        private string img;

        // Constructor
        public CarEN(int code, int category, string name, string desc, double price,
            bool automaticTransmission, int doors, string IMG)
        {
            this.code = code;
            this.category = category;
            this.name = name;
            this.desc = desc;
            this.price = price;
            this.automaticTransmission = automaticTransmission;
            this.doors = doors;
            this.img = IMG;
        }

        // Properties
        public int Code
        {
            set { this.code = value; }
            get { return code; }
        }

        public int Category
        {
            set { this.category = value; }
            get { return category; }
        }

        public string Name
        {
            set { this.name = value; }
            get { return name; }
        }

        public string Desc
        {
            set { this.desc = value; }
            get { return desc; }
        }

        public double Price
        {
            set { this.price = value; }
            get { return price; }
        }

        public bool AutomaticTransmission
        {
            set { this.automaticTransmission = value; }
            get { return automaticTransmission; }
        }

        public int Doors
        {
            set { this.doors = value; }
            get { return doors; }
        }

        public string IMG
        {
            set { this.IMG = value; }
            get { return IMG; }
        }

    }
}