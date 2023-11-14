using AutoMapper;
using Entities.DataTransferObjects;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServicesManager : IServicesManager
    {
        private readonly Lazy<IBookService> _bookService;
        public ServicesManager(IRepositoryManager repositoryManager,
            ILoggerService logger, IMapper mapper,
            IBookLinks bookLinks)
        {
            _bookService = new Lazy<IBookService>(() => 
            new BookManager(repositoryManager, logger, mapper, bookLinks));    
        }
        public IBookService BookService => _bookService.Value;
    }
}
