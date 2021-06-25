using System.Collections.Generic;
using System.Linq;
using BookLoans.Domain.Entities;
using BookLoans.Domain.Interfaces;
using BookLoans.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookLoans.Infra.Repositories
{
    public class LoansRepository : ILoansRepository
    {
        private readonly BookLoansContext _context;
        private readonly DbSet<Loan> _loans;

        public LoansRepository(BookLoansContext context)
        {
            _context = context;
            _loans = context.Loans;
        }
        
        public IEnumerable<Loan> GetAll() => _loans.AsNoTracking().ToList();

        public void Add(Loan loan) => _loans.Add(loan);

        public void Remove(Loan loan) => _loans.Remove(loan);

        public void SaveChanges() => _context.SaveChanges();
    }
}