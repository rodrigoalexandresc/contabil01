namespace Fluxo.SharedKernel.Bus
{
    public interface IMessageConsumer
    {
        //event EventHandler OnMessageReceived;
        void StartConsuming();
        //void StopConsuming();
    }
}
