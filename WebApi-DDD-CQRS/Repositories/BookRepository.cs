using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_DDD_CQRS.DbContexts;

namespace WebApi_DDD_CQRS.Repositories
{
    // to jest struktura danych, ktora przyjdzie do nas z formularza do dodania nowej ksiazki
    public class BookRequestModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Publisher { get; set; }
        public List<AuthorRequestModel> Authors { get; set; } 
            = new List<AuthorRequestModel>();

    }
    public class AuthorRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class BookRepository
    {
        public void Add(Book book)
        {

        }
    }
}
