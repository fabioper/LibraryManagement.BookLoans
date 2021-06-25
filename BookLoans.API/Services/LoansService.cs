using System.Collections.Generic;
using BookLoans.API.Models;
using BookLoans.API.Services.Contracts;
using BookLoans.API.Services.Exceptions;
using BookLoans.Domain.Entities;
using BookLoans.Domain.Interfaces;

namespace BookLoans.API.Services
{
    public class LoansService : ILoansService
    {
        private readonly ILoansRepository _loansRepository;
        private readonly IBooksRepository _booksRepository;

        public LoansService(ILoansRepository loansRepository, IBooksRepository booksRepository)
        {
            _loansRepository = loansRepository;
            _booksRepository = booksRepository;
        }

        public IEnumerable<Loan> GetAll() => _loansRepository.GetAll();

        public void LoanBook(LoanBookRequest request)
        {
            var book = _booksRepository.GetById(request.BookId);
            if (book is null) throw new BookNotFoundException();
            
            var loan = new Loan(request.User, book);
            _loansRepository.Add(loan);
            _loansRepository.SaveChanges();
        }
    }
}