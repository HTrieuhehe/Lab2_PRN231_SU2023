using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using ODataBookStore.Data;
using ODataBookStore.Models;
using System.Linq;

namespace ODataBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ODataController
    {
        private BookStoreContext _db;

        public BooksController(BookStoreContext db)
        {
            _db = db;
            _db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            if (db.Books.Count() == 0)
            {
                foreach (var b in DataSource.GetBooks())
                {
                    db.Books.Add(b);
                    db.Presses.Add(b.Press);
                }
                db.SaveChanges();
            }
        }

        [EnableQuery(PageSize = 1)]
        public IActionResult Get()
        {
            return Ok(_db.Books);
        }

        [EnableQuery]
        public IActionResult Get(int key, string version)
        {
            return Ok(_db.Books.FirstOrDefault(c => c.Id == key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody] Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return Ok(_db);
        }

        [EnableQuery]
        public IActionResult Delete([FromBody] int key)
        {
            Book b = _db.Books.FirstOrDefault(c => c.Id == key); 
            if (b == null)
            {
                return NotFound();
            }
            _db.Books.Remove(b);
            _db.SaveChanges();
            return Ok(_db);
        }
    }
}
