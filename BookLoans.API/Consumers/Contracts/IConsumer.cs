namespace BookLoans.API.Consumers.Contracts
{
    public interface IConsumer<in TMessage>
    {
        void HandleMessage(TMessage message);
    }
}