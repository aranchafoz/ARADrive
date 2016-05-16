using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookingENns;
using ClientENns;

namespace PaymentMethodENns
{

    public class PaymentMethodEN
    {

        private string user;
        private string pass;
        private string client;

        public PaymentMethodEN()
        {
            user = "user";
            pass = "password";
            client = "client";
        }

        public PaymentMethodEN(string user, string password, string cliente)
        {
            this.user = user;
            this.pass = password;
            this.client = cliente;
        }

        public string User
        {
            get { return user; }
            set { this.user = value; }
        }


        public string Pass
        {
            get { return pass; }
            set { this.pass = value; }
        }

        public string Client
        {
            get { return client; }
            set { this.client = value; }
        }

    }

}