using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi_DDD_CQRS.DbContexts;
using WebApi_DDD_CQRS.Services;

namespace WebApi_DDD_CQRS.Handlers
{
    public class BookResponseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Publisher { get; set; }
        public List<AuthorResponseModel> Authors { get; set; }
            = new List<AuthorResponseModel>();

    }
    public class AuthorResponseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class GetBookWithAuthorsRequest : IRequest<BookResponseModel>
    {
        public int BookId { get; set; }
    }

    public class GetBookWithAuthorsHandler
        : IRequestHandler<GetBookWithAuthorsRequest, BookResponseModel>
    {
        private readonly BooksDbContext db;
        private readonly IConfigurationProvider config;

        public GetBookWithAuthorsHandler(
            BooksDbContext db,
            IConfigurationProvider config)
        {
            this.db = db;
            this.config = config;
        }

        public async Task<BookResponseModel> Handle(GetBookWithAuthorsRequest request,
            CancellationToken cancellationToken)
        {
            var response = await db.Books
                                    .Include(b => b.Authors)
                                    .Where(b => b.BookId == request.BookId)
                                    .ProjectTo<BookResponseModel>(this.config)
                                    .FirstOrDefaultAsync();
            return response;
        }
    }

    public class BooksMaps : Profile
    {
        public BooksMaps()
        {
            CreateMap<Book, BookResponseModel>().ReverseMap();
            CreateMap<Author, AuthorResponseModel>().ReverseMap();
        }
    }
}


