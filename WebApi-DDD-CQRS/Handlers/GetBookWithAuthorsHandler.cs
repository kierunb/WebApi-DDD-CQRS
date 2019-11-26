using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
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

        public Task<BookResponseModel> Handle(GetBookWithAuthorsRequest request, 
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
