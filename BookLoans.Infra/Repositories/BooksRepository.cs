using System.Collections.Generic;
using BookLoans.Domain.Entities;
using BookLoans.Domain.Interfaces;

namespace BookLoans.Infra.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        public IEnumerable<Book> Add(Book book)
        {
            throw new System.NotImplementedException();
        }

        public Book GetById(int bookId)
        {
            throw new System.NotImplementedException();
        }
    }
}