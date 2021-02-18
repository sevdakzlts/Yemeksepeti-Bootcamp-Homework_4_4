using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_4_4.Products.Model
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        [Range(0, 4, ErrorMessage = "Product types are 0 = electronic , 1 = public, 2 = private")]
        public int ProductType { get; set; }
        public int IsDeleted { get; set; }
      
    }
}
