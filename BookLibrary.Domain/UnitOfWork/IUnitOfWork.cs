using BookLibrary.Domain.Core.Interfaces;
using BookLibrary.Domain.Entities;

namespace BookLibrary.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Book> BookRepository { get; }
    }
}