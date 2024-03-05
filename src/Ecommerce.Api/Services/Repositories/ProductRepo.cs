using System;
using System.Collections.Generic;
using System.Linq;
using Ecommerce.Models;
using Ecommerce.Models.Models;
using Services.Interfaces;

namespace Services.Repositories
{
    public class ProductRepo : IProduct
    {
        private EcommerceDBContext _dbContext;

        public ProductRepo(EcommerceDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public Product CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public Product GetProduct(string productId)
        {
            return _dbContext.Products.Find(productId);
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }


        public Product UpdateProductById(string productId, Product product)
        {
            // Retrieve the existing product entity from the database
            var existingProduct = _dbContext.Products.FirstOrDefault(p => p.Id == productId);

            // Check if the existing product exists
            if (existingProduct != null)
            {
                // Update the properties of the existing product entity with the new values
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                // Update other properties as needed

                // Save the changes to the database
                _dbContext.SaveChanges();

                return existingProduct;
            }
            else
            {
                // Handle the case where the product does not exist
                throw new InvalidOperationException("Product not found");
            }
        }

    }
}
