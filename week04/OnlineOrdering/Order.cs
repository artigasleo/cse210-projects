using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        if (product != null)
            _products.Add(product);
    }

    public List<Product> GetProducts()
    {
        return _products;
    }

    public Customer GetCustomer()
    {
        return _customer;
    }

    // Shipping cost rule:
    // USA -> $5, otherwise -> $35
    private double GetShippingCost()
    {
        return (_customer != null && _customer.LivesInUSA()) ? 5.0 : 35.0;
    }

    // Calculate total: sum(product totals) + one-time shipping cost
    public double CalculateTotalPrice()
    {
        double sum = 0.0;
        foreach (var p in _products)
        {
            sum += p.GetTotalCost();
        }

        sum += GetShippingCost();
        return sum;
    }

    // Packing label: list name and product id of each product
    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");
        foreach (var p in _products)
        {
            sb.AppendLine($"{p.Name} (ID: {p.ProductId})");
        }
        return sb.ToString();
    }

    // Shipping label: customer name and full address
    public string GetShippingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Shipping Label:");
        sb.AppendLine(_customer.Name);
        sb.AppendLine(_customer.Address.GetFullAddress());
        return sb.ToString();
    }
}
