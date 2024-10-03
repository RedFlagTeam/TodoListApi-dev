using Microsoft.AspNetCore.Mvc;
using MyPublicAPI.Data;
using MyPublicAPI.Models;

namespace MyPublicAPI.Controllers
{
    [Route("publicapi/accounts/[controller]")]
    [ApiController]
    public class AccountController(ApiContext context) : ControllerBase
    {
        private readonly ApiContext _context = context;

        [HttpPost]
        public ActionResult<string> GetAccount(SubAccount subAccount)
        {
            _context.SubAccounts.Add(subAccount);
            _context.SaveChanges();
            return NoContent();
        }
    }
}