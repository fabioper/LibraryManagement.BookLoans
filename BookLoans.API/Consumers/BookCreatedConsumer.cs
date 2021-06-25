using BookLoans.API.Consumers.Messages;
using BookLoans.Domain.Entities;
using BookLoans.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BookLoans.API.Consumers
{
    public class BookCreatedConsumer : Consumer<BookCreated>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public BookCreatedConsumer(IServiceScopeFactory serviceScopeFactory)
            : base("book-created") => _serviceScopeFactory = serviceScopeFactory;

        public override void HandleMessage(BookCreated message)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<BookCreatedConsumer>>();
            var bookRepository = scope.ServiceProvider.GetRequiredService<IBooksRepository>();

            var newBook = new Book(message.BookId);
            bookRepository.Add(newBook);
            bookRepository.SaveChanges();
            
            logger.LogInformation($"Book {newBook.Id} added");
        }
    }
}