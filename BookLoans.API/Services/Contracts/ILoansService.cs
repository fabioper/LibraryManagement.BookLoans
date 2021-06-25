using System.Collections.Generic;
using BookLoans.API.Models;
using BookLoans.Domain.Entities;

namespace BookLoans.API.Services.Contracts
{
    public interface ILoansService
    {
        IEnumerable<Loan> GetAll();
        void LoanBook(LoanBookRequest request);
    }
}