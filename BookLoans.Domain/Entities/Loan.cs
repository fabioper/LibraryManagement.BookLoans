namespace BookLoans.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public string User { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}