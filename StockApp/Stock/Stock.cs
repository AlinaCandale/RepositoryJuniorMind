using System;
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
        List<Product> store = new List<Product>();
        
        public void Add(Product product)
        {
            ProductComparer prdcomp = new ProductComparer();
 
            if (!store.Contains(product, prdcomp))
            {
                store.Add(product);
                CheckQuantity(product.Quantity, product.Name);
            }
            
            else
            {
                int index = store.FindIndex(x => x.Name == product.Name);
                if (index != -1)
                {
                    store[index].Quantity += product.Quantity;
                    CheckQuantity(store[index].Quantity, store[index].Name);
                }
            }
         }

        public void Subtract(Product product)
        {
            int index = store.FindIndex(x => x.Name == product.Name);
            if (index != -1)
            {
                _ = store[index].Quantity < product.Quantity ? throw new Exception() : store[index].Quantity -= product.Quantity;
                CheckQuantity(store[index].Quantity, store[index].Name);
            }
            else
            {
                Console.WriteLine("We don't have any {0} in store", product.Name);
            }
        }

        void CheckQuantity(int n, string name)
        {
            if (n < 10)
            {
                Console.WriteLine("We have left only {0} {1} ", n, name);
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
