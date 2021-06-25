namespace BookLoans.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public string User { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public Loan(string user, Book book)
        {
            User = user;
            Book = book;
        }

        public Loan() // EF required
        {
        }
    }
}