using System.Collections.Generic;
using BookLoans.Domain.Entities;

namespace BookLoans.Domain.Interfaces
{
    public interface ILoansRepository
    {
        IEnumerable<Loan> GetAll();
        void Add(Loan loan);
        void Remove(Loan loan);
    }
}