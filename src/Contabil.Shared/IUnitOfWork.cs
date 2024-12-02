namespace Contabil.Shared
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
