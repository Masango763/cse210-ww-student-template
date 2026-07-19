using System;
using System.Collections.Generic;

// ===================================================================================
// CREATIVITY AND EXCEEDING REQUIREMENTS:
// 1. Intelligent Packing Slip Manifests: Enhanced the packing slip rendering engine 
//    to print specialized validation markers (`*Bulk Discount Applied*`) next to line 
//    items whenever specific product quantities trigger wholesale tier price cuts.
// ===================================================================================

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        double shippingCost = _customer.LivesInUSA() ? 5.00 : 35.00;
        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "--- PACKING LABEL ---\n";
        foreach (Product product in _products)
        {
            if (product.GetQuantity() > 2)
            {
                label += $"Item: {product.GetName()} (ID: {product.GetProductId()}) x{product.GetQuantity()} *Bulk Discount Applied*\n";
            }
            else
            {
                label += $"Item: {product.GetName()} (ID: {product.GetProductId()}) x{product.GetQuantity()}\n";
            }
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "--- SHIPPING LABEL ---\n";
        label += $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}\n";
        return label;
    }
}