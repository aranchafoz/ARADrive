using System;
using BookingENns;

namespace ClientENns
{
    public class ClientEN
    {
        // Attributes
        private string email;
        private string pass;
        private bool premium;
        private string dni;
        private string name;
        private string surname;
        private long phone;
        private string address;
        private string city;
        private Date birthDate;
        private bool drivingLicence;

        // Constructor
        public ClientEN(string email, string pass, bool premium, string dni, string name, string surname,
            long phone, string address, string city, Date birthDate, bool drivingLicense)
        {
            this.email = email;
            this.pass = pass;
            this.premium = premium;
            this.dni = dni;
            this.name = name;
            this.surname = surname;
            this.phone = phone;
            this.address = address;
            this.city = city;
            this.birthDate = birthDate;
            this.drivingLicence = drivingLicense;
        }

        public ClientEN()
        {
            email = "";
            pass = "";
            premium = false;
            dni = "";
            name = "";
            surname = "";
            phone = -1;
            address = "";
            birthDate = new Date(0,0,0);
            drivingLicence = false;
        }

        // Properties
        public string Email
        {
            set { this.email = value; }
            get { return email; }
        }

        public string Pass
        {
            set { this.pass = value; }
            get { return pass; }
        }

        public bool Premium
        {
            set { this.premium = value; }
            get { return premium; }
        }

        public string DNI
        {
            set { this.dni = value; }
            get { return dni; }
        }

        public string Name
        {
            set { this.name = value; }
            get { return name; }
        }

        public string Surname
        {
            set { this.surname = value; }
            get { return surname; }
        }

        public long Phone
        {
            set { this.phone = value; }
            get { return phone; }
        }

        public string Address
        {
            set { this.address = value; }
            get { return address; }
        }

        public string City
        {
            set { this.city = value; }
            get { return city; }
        }

        public Date BirthDate
        {
            set { this.birthDate = value; }
            get { return birthDate; }
        }

        public bool DrivingLicence
        {
            set { this.drivingLicence = value; }
            get { return drivingLicence; }
        }

    }

}