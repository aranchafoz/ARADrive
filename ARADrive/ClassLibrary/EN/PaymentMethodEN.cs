using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookingENns;
using ClienENns;

namespace PaymentMethodENns
{

    public class PaymentMethodEN
    {

        private PaymentMethodEN paymentMethod;


        private string user;
        private string pass;
        private ClientEN client;

        public PaymentMethodEN()
        {
            user = "user";
            pass = "password";
        }

        public PaymentMethodEN(string user, string password, ClientEN cliente)
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

        public ClientEN Client
        {
            get { return client; }
            set { this.client = value; }
        }

    }

}