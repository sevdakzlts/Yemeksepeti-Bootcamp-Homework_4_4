using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework_4_4.Products.Model;
using Microsoft.AspNetCore.Mvc;

namespace Homework_4_4.Products.Controllers
{
    public class ProductTypeController : ControllerBase
    {
        public List<ProductType> ProductTypes = new List<ProductType>();

        [HttpPost]
        public ActionResult Post(ProductType newType)
        {
            if (ProductTypes.Find(p => p.Id == newType.Id) != null)
            {
                return null;
            }

            ProductTypes.Add(newType);

            return Ok();
        }

        public ActionResult Get()
        {
            return Ok(ProductTypes);
        }
    }
}
