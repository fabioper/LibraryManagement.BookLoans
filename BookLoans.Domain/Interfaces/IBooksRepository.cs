using System.Collections.Generic;
using BookLoans.Domain.Entities;

namespace BookLoans.Domain.Interfaces
{
    public interface IBooksRepository
    {
        void Add(Book book);
        Book GetById(int bookId);
        void SaveChanges();
    }
}