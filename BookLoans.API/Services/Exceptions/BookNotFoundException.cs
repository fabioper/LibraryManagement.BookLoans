using System;

namespace BookLoans.API.Services.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException() : base("Livro especificado não existe em nossa base de dados.")
        {
        }
    }
}