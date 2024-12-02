namespace Fluxo.SharedKernel.Bus
{
    public interface IMessageSender
    {
        Task Send<T>(string topicOrQueue, T message);
    }
}
