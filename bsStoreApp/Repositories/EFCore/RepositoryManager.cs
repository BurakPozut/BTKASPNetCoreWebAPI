using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RepositoryManager(RepositoryContext repositoryContext,
            IBookRepository bookRepository, 
            ICategoryRepository categoryRepository)
        {
            _repositoryContext = repositoryContext;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        //private readonly Lazy<IBookRepository> _bookRepository;
        //private readonly Lazy<ICategoryRepository> _categoryRepository;

        //public RepositoryManager(RepositoryContext repositoryContext)
        //{
        //    _repositoryContext = repositoryContext;
        //    _bookRepository = new Lazy<IBookRepository>(()=> new BookRepository(_repositoryContext));
        //    _categoryRepository = new Lazy<ICategoryRepository>(()=> 
        //    new CategoryRepository(_repositoryContext));
        //}

        public IBookRepository Book => _bookRepository;

        public ICategoryRepository Category => _categoryRepository;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
