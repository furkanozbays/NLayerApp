namespace NLayerApp.Core;

public interface IUnitOfWork
{
    Task CommitAsync();
    void Commit();
}