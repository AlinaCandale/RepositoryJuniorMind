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

     public class Stock
    {
        public List<Product> itemsList = new List<Product>();

        public Action<Product,int> callBack;

        List<int> thresholds = new List<int>() { 2, 5, 10 };

        public void CheckQuantity(int initialQuantity, int substractedQuantity, Product product)
        {
            if (thresholds.Any(threshold => initialQuantity >= threshold && initialQuantity - substractedQuantity < threshold))
            {
                callBack(product, initialQuantity - substractedQuantity);
            }
        }

        public void Add(Product product)
        {
            ProductComparer prdcomp = new ProductComparer();

            if (!itemsList.Contains(product, prdcomp))
            {
                itemsList.Add(product);
            }
            else
            {
                int index = itemsList.FindIndex(x => x.Name == product.Name);
                if (index != -1)
                {
                    itemsList[index].Quantity += product.Quantity;
                }
            }
         }

        public void Subtract(Product product)
        {
            int index = itemsList.FindIndex(x => x.Name == product.Name);
            if (index != -1)
            {
                CheckQuantity(itemsList[index].Quantity, product.Quantity, itemsList[index]);
                _ = itemsList[index].Quantity < product.Quantity ? throw new Exception() : itemsList[index].Quantity -= product.Quantity;
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
