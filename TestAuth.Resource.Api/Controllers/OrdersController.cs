using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAuth.Resource.Api.Models;

namespace TestAuth.Resource.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly BookStore _store;
        private Guid UserId => Guid.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public OrdersController(BookStore store)
        {
            _store = store;
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        [Route("")]
        public IActionResult GetOrders()
        {
            if (!_store.Orders.ContainsKey(UserId)) 
            {
                return Ok(Enumerable.Empty<Book>());
            }

            var orderedBooksId = _store.Orders.Single(o => o.Key == UserId).Value;
            var orderedBooks = _store.Books.Where(b => orderedBooksId.Contains(b.Id));
            return Ok(orderedBooks);
        }
    }
}
