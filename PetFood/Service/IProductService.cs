using PetFood.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFood.Service
{
    public interface IProductService
    {
        List<Product> GetProducts();
      
        List<Product> SortProducts(string sortvalue);
        List<Product> GetProductDetail(int productId);
        List<Product> GetProductsById(List<int> ids);
    }
}
