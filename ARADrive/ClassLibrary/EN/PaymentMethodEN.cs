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
        private string password;
        private ClientEN cliente;

        public PaymentMethodEN()
        {
            user = "user";
            password = "password";
        }

        public PaymentMethodEN(string user, string password, ClientEN cliente)
        {
            this.user = user;
            this.password = password;
            this.cliente = cliente;
        }

        public string User
        {
            get { return user; }
            set { this.user = value; }
        }


        public string Password
        {
            get { return password; }
            set { this.password = value; }
        }

        public ClientEN Cliente
        {
            get { return cliente; }
            set { this.cliente = value; }
        }

    }

}