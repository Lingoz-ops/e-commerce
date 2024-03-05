using System.Collections.Generic;
using Ecommerce.Models.Models;

namespace Services.Interfaces
{
    public interface IProduct
    {
        Product CreateProduct(Product product);
        Product GetProduct(string productId);
        //void RemoveProductsByIds(OrderProduct productIds);
        IEnumerable<Product> GetAllProducts();
        Product UpdateProductById(string productId, Product product);
    }
}
