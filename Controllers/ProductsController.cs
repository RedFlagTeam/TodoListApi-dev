using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPublicAPI.Data;
using MyPublicAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyPublicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiContext _context;

        private string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwidXNlcl9pZCI6IjkxZTUyNzFjLTRlZjUtNGRjNy05ZDcyLTI1NTNmYjllZGZjNCIsInVzZWRfZm9yIjoiQm9raW8gRGVtbyIsImlhdCI6MTUxNjIzOTAyMn0.SxB83Le6FxypBuDVF_YCt8bNoh7iAKfxIcLwA4BBZQY"

        public ProductsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet("/token")]
        public ActionResult<string> getToken()
        {
            return token;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}