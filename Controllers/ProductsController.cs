using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPublicAPI.Data;
using MyPublicAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyPublicAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController(ApiContext context) : ControllerBase
    {
        private readonly ApiContext _context = context;

        private readonly string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwidXNlcl9pZCI6IjkxZTUyNzFjLTRlZjUtNGRjNy05ZDcyLTI1NTNmYjllZGZjNCIsInVzZWRfZm9yIjoiQm9raW8gRGVtbyIsImlhdCI6MTUxNjIzOTAyMn0.SxB83Le6FxypBuDVF_YCt8bNoh7iAKfxIcLwA4BBZQY";

        [HttpGet("/token")]
        public ActionResult<string> getToken()
        {
            return token;
        }
    }
}