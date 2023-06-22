using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataBookStore.Data;
using ODataBookStore.Models;
using System.Linq;

namespace ODataBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PressController : ODataController
    {
        private BookStoreContext _db;

        public PressController(BookStoreContext db)
        {
            _db = db;
            if (db.Books.Count() == 0)
            {
                foreach(var b in DataSource.GetBooks())
                {
                    db.Books.Add(b);
                    db.Presses.Add(b.Press);
                }

                db.SaveChanges();
            }
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.Presses);
        }
    }
}
