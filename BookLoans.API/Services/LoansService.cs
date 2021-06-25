using System.Collections.Generic;
using BookLoans.API.Events;
using BookLoans.API.Models;
using BookLoans.API.Services.Contracts;
using BookLoans.API.Services.Exceptions;
using BookLoans.Domain.Entities;
using BookLoans.Domain.Interfaces;
using BookLoans.Infra.Messaging.Contracts;
using Microsoft.Extensions.Logging;

namespace BookLoans.API.Services
{
    public class LoansService : ILoansService
    {
        private readonly ILoansRepository _loansRepository;
        private readonly IBooksRepository _booksRepository;
        private readonly IServiceBus _serviceBus;
        private readonly ILogger<LoansService> _logger;

        public LoansService(ILoansRepository loansRepository, IBooksRepository booksRepository, IServiceBus serviceBus, ILogger<LoansService> logger)
        {
            _loansRepository = loansRepository;
            _booksRepository = booksRepository;
            _serviceBus = serviceBus;
            _logger = logger;
        }

        public IEnumerable<Loan> GetAll()
        {
            _logger.LogInformation("Retrieving all loans");
            return _loansRepository.GetAll();
        }

        public void LoanBook(LoanBookRequest request)
        {
            _logger.LogInformation($"Trying to lend a book with ID: {request.BookId}");
            var book = _booksRepository.GetById(request.BookId);
            if (book is null)
            {
                _logger.LogWarning($"Loan with ID {request.BookId} not found");
                throw new BookNotFoundException();
            }

            var loan = new Loan(request.User, book);
            _loansRepository.Add(loan);
            _loansRepository.SaveChanges();

            _serviceBus.Publish(new BookLoaned(loan.BookId));
            
            _logger.LogInformation($"Book {loan.BookId} was lent to {loan.User}");
        }
    }
}