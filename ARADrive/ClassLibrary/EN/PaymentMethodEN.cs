using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

 public class PaymentMethodEN {

    private PaymentMethodEN paymentMethod;


    private string user;
    private string password;

    public PaymentMethodEN()
    {
        user = "user";
        password = "password";
    }

    public PaymentMethodEN(string user, string password)
    {
        this.user = user;
        this.password = password;
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
		
}

