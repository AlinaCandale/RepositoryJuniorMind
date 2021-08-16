﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Stock
{
    public class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] Product obj)
        {
            return obj.Name == null ? 0 : obj.Name.GetHashCode();
        }
    }

    public delegate void Dell();
    public class Stock
    {
        public List<Product> itemsList = new List<Product>();

        public Dell callback;
        public void CheckQuantity(int n, string m)
        {
            if (n < 10)
            {
                Console.WriteLine($"We have left only {n} {m}");
                callback();
            }
        }
 
        public void Add(Product product)
        {
            ProductComparer prdcomp = new ProductComparer();

            if (!itemsList.Contains(product, prdcomp))
            {
                itemsList.Add(product);
                CheckQuantity(product.Quantity, product.Name);
            }
            else
            {
                int index = itemsList.FindIndex(x => x.Name == product.Name);
                if (index != -1)
                {
                    itemsList[index].Quantity += product.Quantity;
                    CheckQuantity(itemsList[index].Quantity, itemsList[index].Name);
                }
            }
         }

        public void Subtract(Product product)
        {
            int index = itemsList.FindIndex(x => x.Name == product.Name);
            if (index != -1)
            {
                _ = itemsList[index].Quantity < product.Quantity ? throw new Exception() : itemsList[index].Quantity -= product.Quantity;
                CheckQuantity(itemsList[index].Quantity, itemsList[index].Name);
            }
            else
            {
                Console.WriteLine("We don't have any {0} in store", product.Name);
            }
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Product(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
