using System.Collections.Generic;
using BookLoans.Domain.Entities;
using BookLoans.Domain.Interfaces;

namespace BookLoans.Infra.Repositories
{
    public class LoansRepository : ILoansRepository
    {
        public IEnumerable<Loan> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Add(Loan loan)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Loan loan)
        {
            throw new System.NotImplementedException();
        }
    }
}