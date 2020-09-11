using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAuth.Resource.Api.Models;

namespace TestAuth.Resource.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStore _store;

        public BooksController(BookStore store)
        {
            _store = store;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetAvailableBooks()
        {
            return Ok(_store.Books);
        }
    }
}
