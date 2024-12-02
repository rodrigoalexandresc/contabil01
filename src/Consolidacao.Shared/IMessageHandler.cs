namespace Consolidacao.Shared
{
    public interface IMessageHandler
    {
        Task Handle<T>(T message);
    }
}
