using System;
using System.Dynamic;
using System.Net.Mail;
using System.Numerics;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        // Testing  Product class
        Console.WriteLine("Testing Product class:");
        Product product1 = new Product("macbook", 1001, 999.99, 2);
        Console.WriteLine($"Product Name: {product1._name}");
        Console.WriteLine($"Product ID: {product1._productID}");
        Console.WriteLine($"Price Per Unit: ${product1._pricePU}");
        Console.WriteLine($"Quantity: {product1._numberOP}");
        Console.WriteLine($"Total Cost: ${product1.totalCost(product1._pricePU, product1._numberOP)}");
    }
}

class Product
{
    public string _name;
    public int _productID;
    public double _pricePU;
    public int _numberOP;

  
public string Name { get { return _name; } }

public int ProductID { get { return _productID; } }

public double PricePerUnit { get { return _pricePU; } }

public int Quantity { get { return _numberOP; } }

    public Product(string name, int productID, double pricePU, int numberOP)
    {
        _name = name;
        _productID = productID;
        _pricePU = pricePU;
        _numberOP = numberOP;

    }
    public double totalCost(double pricePU, int numberOP)
    {
        return _pricePU * numberOP;
    }

}
class Customer
{
    private string _customerID;
    private Address _addressC;



    public Customer(string customerID, Address addressC)
    {
        _customerID = customerID;
        Address _addressC = addressC;


    }

}

class Address
{
    public string _street;
    public string _City;
    public string _state;
    public string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _City = city;
        _state = state;
        _country = country;

    }
    public string DomesticOrForeign()
    {
        if (_country == "USA")
        {
            return "Domestic";
        }
        else
        {
            return "Foreign";
        }

    }
    public  string DisplayAddress()
    {
        return _street + _City + _state + _country;
    }

}

class Order
{
    private List<Order> orders = new List<Order>();

    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;


    }
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    
}
