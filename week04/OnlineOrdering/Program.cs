using System;

// ===================================================================================
// CREATIVITY AND EXCEEDING REQUIREMENTS:
// 1. Bulk Discount Pricing Matrix: Implemented dynamic line-item pricing adjustments. 
//    If a customer orders more than 2 units of any single product line, the system 
//    automatically triggers a 10% unit price deduction for that item.
// ===================================================================================

public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetDiscountedUnitPrice()
    {
        if (_quantity > 2)
        {
            return _price * 0.90; // 10% markdown applied
        }
        return _price;
    }

    public double GetTotalCost()
    {
        return GetDiscountedUnitPrice() * _quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetProductId()
    {
        return _productId;
    }

    public int GetQuantity()
    {
        return _quantity;
    }
}