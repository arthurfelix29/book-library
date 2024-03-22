using BookLibrary.Domain.Core.Interfaces;
using BookLibrary.Domain.Entities;
using BookLibrary.Domain.UnitOfWork;
using BookLibrary.Infra.Data.Contexts;
using BookLibrary.Infra.Data.Repositories;

namespace BookLibrary.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookLibraryContext _dbContext;

        private IRepository<Book> _bookRepository;

        public UnitOfWork(BookLibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<Book> BookRepository => _bookRepository ??= new Repository<Book>(_dbContext);
    }
}