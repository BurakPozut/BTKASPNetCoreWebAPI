using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServicesManager : IServicesManager
    {
        private readonly Lazy<IBookService> _bookService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<ICategoryService> _categoryService;
        public ServicesManager(IRepositoryManager repositoryManager,
            ILoggerService logger, IMapper mapper,
            IBookLinks bookLinks, UserManager<User> userManager,
            IConfiguration configuration)
        {
            _bookService = new Lazy<IBookService>(() => 
            new BookManager(repositoryManager, logger, mapper, bookLinks));

            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationManager(logger,mapper,userManager, configuration));

            _categoryService = new Lazy<ICategoryService>(() => new CategoryManager(repositoryManager));
        }
        public IBookService BookService => _bookService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public ICategoryService CategoryService => _categoryService.Value;
    }
}
