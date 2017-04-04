namespace TeamBuilder.Data.Contracts
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
