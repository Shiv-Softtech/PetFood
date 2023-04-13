using PetFood.Entity;
using PetFood.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetFood.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
           /// <summary>
           /// get all products to productList page
           /// </summary>
           /// <returns></returns>
        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        /// <summary>
        /// get all sorted product like high to low 
        /// </summary>
        /// <param name="sortvalue"></param>
        /// <returns></returns>
        public List<Product> SortProducts(string sortvalue)
        {
           return _productRepository.SortProducts(sortvalue);
        }

        /// <summary>
        /// get product id and show productdetail page 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public List<Product> GetProductDetail(int productId)
        {
            return _productRepository.GetProductDetail(productId);

        }

        /// <summary>
        /// get product to list of ids and show basket and wishlist
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<Product> GetProductsById(List<int> ids)
        {
            List<Product> product = _productRepository.GetProducts();
            return product.Where(x => ids.Contains(x.Id)).ToList();

        }
    }
}