using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;
        public ProductRepository(Context context)
        {
            _context = context;
        }


        // Get all products
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }

        // Get product by id
        public Product GetProductById(Guid id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            return product;

        }

        //Create a product
        public bool AddProduct(string name, decimal price)
        {
            var product = new Product(Guid.NewGuid(), name, price);

            _context.Add(product);
            _context.SaveChanges();

            return true;
        }


        // Update product
        public bool UpdateProduct(Guid id, Product product)
        {
            var productToUpdate = _context.Products.FirstOrDefault(x=>x.Id==id);
            if (productToUpdate != null)
            {
                productToUpdate.Id = product.Id;
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;

                _context.Update(productToUpdate);
                _context.SaveChanges();
                return true;
            }

            return false;

        }

        //Delete product
        public bool DeleteProduct(Guid id)
        {
            var productToDelete = _context.Products.FirstOrDefault(x=>x.Id==id);
            _context.Remove(productToDelete);

            _context.SaveChanges();

            return true;
        }

    }
}
