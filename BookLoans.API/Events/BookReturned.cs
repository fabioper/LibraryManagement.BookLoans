using BookLoans.Infra.Messaging;

namespace BookLoans.API.Events
{
    public class BookReturned : EventMessage
    {
        public BookReturned(int bookId)
        {
            BookId = bookId;
        }

        public int BookId { get; set; }
        
        public override string QueueName() => "book-returned";
    }
}