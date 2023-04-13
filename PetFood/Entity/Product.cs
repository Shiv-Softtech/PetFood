using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetFood.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public string Image_one { get; set; }
        public string Image_two { get; set; }
        public string Hover_Image { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }

        public int Size { get; set; }
        public string Color { get; set; }

        public string FeatureValue { get; set; }
        public string Brand { get; set; }
        public string Tag { get; set; }

    }
}