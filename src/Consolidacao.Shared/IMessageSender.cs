namespace Consolidacao.Shared
{
    public interface IMessageSender
    {
        Task Send<T>(string topicOrQueue, T message);
    }
}
