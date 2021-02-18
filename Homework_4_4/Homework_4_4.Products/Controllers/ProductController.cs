using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework_4_4.Products.Data;
using Homework_4_4.Products.Model;

namespace Homework_4_4.Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DummyData _dummyData;

        public ProductController(DummyData dummyData)
        {
            _dummyData = dummyData;
        }

        [HttpGet]
        public ActionResult<List<Model.Products>> Get()
        {
            return Ok(_dummyData.Products.Where(p => p.IsDeleted != 1).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Model.Products> Get(int id)
        {
            var data = _dummyData.Products.FirstOrDefault(c => c.Id == id);
            if (data != null)
            {
                return Ok(data);
            }

            return NoContent();
        }

        [HttpPut]
        public ActionResult Put(Model.Products product)
        {
            var data = _dummyData.Products.FirstOrDefault(c => c.Id == product.Id);
            if (data != null)
            {
                data.Name = product.Name;
                data.ProductType = product.ProductType;
                data.Price = product.Price;
            }
            else
            {
                data = new Model.Products();
                {
                    int Id = _dummyData.Products.Count;
                    int Price = product.Price;
                    string Name = product.Name;
                    int ProductType = product.ProductType;
                };
                _dummyData.Products.Add(data);
            }

            return Ok(data);
        }

        [HttpPost]
        public ActionResult Post(Model.Products product)
        {
            product.Id = _dummyData.Products.Count;
            product.IsDeleted = 0;
            _dummyData.Products.Add(product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public ActionResult<Model.Products> Delete(int id)
        {
            var data = _dummyData.Products.FirstOrDefault(c => c.Id == id && c.IsDeleted == 0);
            if (data != null)
            {
                data.IsDeleted = 1;
                return Ok();
            }

            return NoContent();
        }
    }
}
