using BookLoans.Infra.Messaging;

namespace BookLoans.API.Events
{
    public class BookLoaned : EventMessage
    {
        public BookLoaned(int bookId) => BookId = bookId;

        public int BookId { get; set; }
        public override string QueueName() => "book-loaned";
    }
}