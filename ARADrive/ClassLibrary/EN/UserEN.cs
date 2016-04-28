using System;

public class UserEN
{
    // Attributes
    private string email;
    private string pass;
    private bool premium;
    private string dni;
    private string name;
    private string surname;
    private int phone;
    private string address;
    private string city;
    private DateTime birthDate;
    private bool drivingLicense;

    // Constructor
	public UserEN(string email, string pass, bool premium, string dni, string name, string surname,
        int phone, string address, string city, DateTime birthDate, bool drivingLicense)
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
        this.drivingLicense = drivingLicense;
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

    public string Dni
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

    public int Phone
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

    public DateTime BirthDate
    {
        set { this.birthDate = value; }
        get { return birthDate; }
    }

    public bool DrivingLicense
    {
        set { this.drivingLicense = value; }
        get { return drivingLicense; }
    }

}

