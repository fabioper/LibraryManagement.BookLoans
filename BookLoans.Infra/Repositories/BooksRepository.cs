using System.Collections.Generic;
using System.Linq;
using BookLoans.Domain.Entities;
using BookLoans.Domain.Interfaces;
using BookLoans.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BookLoans.Infra.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookLoansContext _context;
        private readonly DbSet<Book> _books;

        public BooksRepository(BookLoansContext context)
        {
            _context = context;
            _books = _context.Books;
        }
        
        public void Add(Book book) => _books.Add(book);

        public Book GetById(int bookId) => _books.Find(bookId);

        public void SaveChanges() => _context.SaveChanges();
    }
}