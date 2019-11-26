﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi_DDD_CQRS.DbContexts;
using WebApi_DDD_CQRS.ResponseModels;


namespace WebApi_DDD_CQRS.Handlers
{
    // W koszernym CQRS mamy klasy typu Query i Command
    // w mediatorze mamy po prostu Request / Response


    // BookId --> HANDLER --> BookResponseModel

    // IRequest -> model wejsciowy
    // IRequestHandler -> handler dla danego modelu

    public class GetBookByIDRequest : IRequest<GetBookByIDResponseModel>
    {
        public int BookId { get; set; }
    }

    // handler implementuje interfejs IRequestHandler<Model Wejsciowy, Model wyjsciwy>

    public class GetBookByIDRequestHandler : IRequestHandler<GetBookByIDRequest, GetBookByIDResponseModel>
    {
        private readonly BooksDbContext db;

        public GetBookByIDRequestHandler(BooksDbContext db)
        {
            this.db = db;
        }
        
        public async Task<GetBookByIDResponseModel> Handle(GetBookByIDRequest request, 
                                                        CancellationToken cancellationToken)
        {
            // pobierzemy dokladnie te dane ktore trzeba
            // i zmapujemy na model wyjsciowy

            var response = await db.Books
                .Select(b => new GetBookByIDResponseModel{ 
                    BookId = b.BookId,
                    Description = b.Description,
                    Language = b.Language,
                    Title = b.Title,
                    PublishedOn = b.PublishedOn,
                    Publisher = b.Publisher
                })
                .FirstOrDefaultAsync(b => b.BookId == request.BookId);
                
            
            return response;
        }
    }
}