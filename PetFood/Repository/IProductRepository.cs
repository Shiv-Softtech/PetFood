using PetFood.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFood.Repository
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        List<Product> SortProducts(string productData);
        List<Product> GetProductDetail(int productId);
    }
}
