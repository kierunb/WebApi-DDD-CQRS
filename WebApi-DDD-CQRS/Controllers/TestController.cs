using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi_DDD_CQRS.DbContexts;
using WebApi_DDD_CQRS.Repositories;

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

        [HttpPost]
        [Route("add-book-v1")]
        public async Task<ActionResult> AddBookVersion1Async(
            [FromBody]BookRequestModel request)
        {

            // service.AddBook(request)
            
            
            // Wstrzykujemy Repository
            // BookRepository - br
            // AuthorRepository - ar
            // ile repozytoriów - 2
            // czy unit of work? (bo ma byc transakcja) - tak
            // jakiego typu parametry wejsciowe maja byc w repozytoriach?
            // czy requstModel, czy data model

            // raczej bedziemy mapowac model (AutoMapper)
            // mapuje zanim przekazemy dane do repozytorium
            // repozytorium operuje na data modelu

            // var autorRepo
            // var bookRepo

            // var BookAuthorService
            // baService.AddBookWithAuthors()
                    //  logika biznowa + zapis danych + mapowanie + walidacja


            // Author[] autors = request.Authors;
            // Authors[] autorzyuZID = autorRepo.AddIfExist(autors)

            // var book = requestModel.Book
            // book.add(autorzyZID);
            // var id = authorRepo.Add(book);

            

            // bookRepo.AddNewBook(bookWithAuthors);


            return Ok("book added");
        }


        [HttpGet]
        [Route("add-book")]
        public async Task<ActionResult> AddBookAsync()
        {
            // RequestModel
            // struktura danych
                // dane ksiazki
                // dane 1..n autorów
            // model opisuje dane przekazane z formularza
            
            // mapowanie na obiekty entity frameworka
            // BookRepository
            // AuthorRepository
            // 

            // 1. za





            var book = new Book { Title = "Plastusiowy Pamiernik", Description = "Sci-Fi", Publisher = "Nova" };
            book.Authors.Add(new Author { FirstName = "Kownacka", LastName = "Maria" });
            book.Authors.Add(new Author { FirstName = "Maria", LastName = "Konopnicka" });
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
