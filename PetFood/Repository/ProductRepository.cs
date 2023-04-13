using PetFood.Data;
using PetFood.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetFood.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IPetFoodFactoryData _petFoodFactoryData;
        private PetFoodDataContext _petFoodDataContext;
        public ProductRepository(IPetFoodFactoryData petFoodFactoryData)
        {
            _petFoodFactoryData = petFoodFactoryData;
            _petFoodDataContext = petFoodFactoryData.PetFoodDataContext();
        }
        // get all product by Db 
        public List<Product> GetProducts()
        {
            var productRep = _petFoodDataContext.GetProducts_20220905().ToList();    
            var productResp = (from o in productRep
                               select new Product
                               {
                                   Id = o.Id,
                                   Title = o.Title,
                                   Price = (decimal)o.Price,
                                   Rating = (int)o.Rating,
                                   Image = o.image,
                                   Hover_Image = o.Hover_Image,
                                   Category = o.Categories,
                                   Size = (int)o.Size,
                                   Color = o.Color,
                                   Brand = o.Brand,
                                   Tag=o.Tag
                               }).ToList();
            return productResp;
        }
        // get all product by sortvalue like lowtohigh price 
        public List<Product> SortProducts(string productData)
        {
            var sortProducts = _petFoodDataContext.SortProduct_20220906(productData).ToList();
            var sortProductsRep = (from o in sortProducts
                                 select new Product
                                 {
                                     Id = o.Id,
                                     Title = o.Title,
                                     Price = (decimal)o.Price,
                                     Rating = (int)o.Rating,
                                     Image = o.image,
                                     Hover_Image = o.Hover_Image,
                                     Category = o.Categories,
                                     Size = (int)o.Size,
                                     Color = o.Color,
                                     Brand = o.Brand,
                                     Tag=o.Tag
                                 }).ToList();
            return sortProductsRep;
        }
        // get product by id 
        public List<Product> GetProductDetail(int productId)
        {
            var productDetailRepo = _petFoodDataContext.productDetail_20220909(productId).ToList();
            var productDetail = (from o in productDetailRepo
                                 select new Product
                                 {
                                     Id = o.Id,
                                     Title = o.Title,
                                     Price = (decimal)o.Price,
                                     Rating = (int)o.Rating,
                                     Image = o.image,
                                     Image_one = o.image_one,
                                     Image_two = o.image_two,
                                     Hover_Image = o.Hover_Image,
                                     Category = o.Categories,
                                     Size = (int)o.Size,
                                     Color = o.Color
                                 }).ToList();
            return productDetail;


        }
    }
}