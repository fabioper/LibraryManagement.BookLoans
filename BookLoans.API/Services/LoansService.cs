using System.Collections.Generic;
using BookLoans.API.Events;
using BookLoans.API.Models;
using BookLoans.API.Services.Contracts;
using BookLoans.API.Services.Exceptions;
using BookLoans.Domain.Entities;
using BookLoans.Domain.Interfaces;
using BookLoans.Infra.Messaging.Contracts;

namespace BookLoans.API.Services
{
    public class LoansService : ILoansService
    {
        private readonly ILoansRepository _loansRepository;
        private readonly IBooksRepository _booksRepository;
        private readonly IServiceBus _serviceBus;

        public LoansService(ILoansRepository loansRepository, IBooksRepository booksRepository, IServiceBus serviceBus)
        {
            _loansRepository = loansRepository;
            _booksRepository = booksRepository;
            _serviceBus = serviceBus;
        }

        public IEnumerable<Loan> GetAll() => _loansRepository.GetAll();

        public void LoanBook(LoanBookRequest request)
        {
            var book = _booksRepository.GetById(request.BookId);
            if (book is null) throw new BookNotFoundException();
            
            var loan = new Loan(request.User, book);
            _loansRepository.Add(loan);
            _loansRepository.SaveChanges();

            _serviceBus.Publish(new BookLoaned(loan.BookId));
        }
    }
}