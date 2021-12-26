using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketContext _db;

        public ProductRepository(MarketContext db)
        {
            _db = db;
        }

        public void AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _db.Products.Find(productId);
            if (product == null) return;

            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            return _db.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _db.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _db.Products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var prod = _db.Products.Find(product.ProductId);
            if(prod == null) return;

            prod.CategoryId = product.CategoryId;
            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;
            
            _db.SaveChanges();
        }
    }
}
