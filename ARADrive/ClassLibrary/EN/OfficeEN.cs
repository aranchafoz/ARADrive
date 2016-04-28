using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


 public class OfficeEN {

     private int code;
     private string name;
     private string address;
     private string city;
     private float cX;
     private float cY;


     public OfficeEN (int code, string name, string address, string city, float cX, float cY )
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

     public float CX
     {
         get { return cX; }
         set { this.cX = value; }
     }

     public float CY
     {
         get { return cY; }
         set { this.cY = value; }
     }


}