using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Services
{
    public interface IProductRepository
    {
       
        IEnumerable<Product> GetProducts();
        Product GetProductById(Guid id);
        bool AddProduct(string name, decimal price);
        bool UpdateProduct(Guid id, Product product);
        bool DeleteProduct(Guid id);
        
    }
}
