using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServicesManager : IServicesManager
    {
        private readonly Lazy<IBookService> _bookService;
        public ServicesManager(IRepositoryManager repositoryManager,
            ILoggerService logger)
        {
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager, logger));
        }
        public IBookService BookService => _bookService.Value;
    }
}
