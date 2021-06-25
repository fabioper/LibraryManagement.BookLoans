namespace BookLoans.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public Loan Loan { get; set; }
    }
}