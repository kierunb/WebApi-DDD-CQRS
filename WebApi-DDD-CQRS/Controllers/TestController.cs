using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi_DDD_CQRS.DbContexts;

namespace WebApi_DDD_CQRS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {


        private readonly ILogger<TestController> logger;
        private readonly BooksDbContext db;

        public TestController(
            ILogger<TestController> logger,
            BooksDbContext db)
        {
            this.logger = logger;
            this.db = db;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            logger.LogInformation("inside get method");
            return Ok("I'm alive");
        }


        [HttpGet]
        [Route("add-book")]
        public async Task<ActionResult> AddBookAsync()
        {

            var book = new Book { Title = "Dzienniki Gwiazdowe", Description = "Sci-Fi", Publisher = "Nova" };
            book.Authors.Add(new Author { FirstName = "Stanislaw", LastName = "Lem" });
            db.Books.Add(book);
            await db.SaveChangesAsync();

            return Ok("book sucesfully saved");
        }

        [HttpGet]
        [Route("get-book/{id}")]
        public async Task<ActionResult> GetBookAsync(int id)
        {

            var book = await db.Books
                //.Include(b => b.Authors)        
                .FirstOrDefaultAsync(b => b.BookId == id);

            return Ok(book);
        }

    }
}
