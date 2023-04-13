using AutoMapper;
using PetFood.Entity;
using PetFood.Models;
using PetFood.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetFood.Controllers
{
    public class ProductController : Controller
    {
       
        private readonly IProductService _productService;
        public ProductController( IProductService productService)
        {
           
            _productService = productService;

        }
        // GET: Product list page view
        public ActionResult Product()
        {
            return View();
        }
        //product detail page
        public ActionResult ProductDetail()
        {
            return View();
        }
        public ActionResult AddToBasket()
        {
            return View();
        }
        public ActionResult WishList()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetProducts()
        {
            var productInfo = _productService.GetProducts();
            var productDetail = Mapper.Map<List<Product>, List<ProductModel>>(productInfo);
            return Json(productDetail, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SortProducts(string FeatureValue)
        {

            var productPrice = _productService.SortProducts(FeatureValue);
            var productDetail = Mapper.Map<List<Product>, List<ProductModel>>(productPrice);

            return Json(productDetail, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ProductDetail(int productID)
        {
            var productDetail = _productService.GetProductDetail(productID);
            var productPageDetail = Mapper.Map<List<Product>, List<ProductModel>>(productDetail);
            return Json(productPageDetail, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// name is store cookiesname
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        [HttpPost]
        public JsonResult AddToBasket(string name)
        {
            var addtocartcookie = Request.Cookies[name];

            if (addtocartcookie != null)
            {
                var productIds = addtocartcookie.Value;
                var ids = productIds.Split('-');
                List<int> pids = ids.Select(x => int.Parse(x)).ToList();
                var product = _productService.GetProductsById(pids);
                return Json(product, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}