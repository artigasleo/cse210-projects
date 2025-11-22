using System;

public class Product
{
    private string _name;
    private string _productId;
    private double _pricePerUnit;
    private int _quantity;

    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        _name = name;
        _productId = productId;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string ProductId
    {
        get => _productId;
        set => _productId = value;
    }

    public double PricePerUnit
    {
        get => _pricePerUnit;
        set => _pricePerUnit = value;
    }

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value;
    }

    // Total cost for this product (price * quantity)
    public double GetTotalCost()
    {
        return _pricePerUnit * _quantity;
    }
}
