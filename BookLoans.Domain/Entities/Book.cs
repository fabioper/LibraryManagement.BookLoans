namespace BookLoans.Domain.Entities
{
    public class Book
    {
        public Book(int bookId) => Id = bookId;

        public int Id { get; set; }
        public Loan Loan { get; set; }

        public Book() // EF required
        {
        }
    }
}