using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServicesManager
    {
        IBookService BookService { get; }
        IAuthenticationService AuthenticationService { get; }
        ICategoryService CategoryService { get; }
    }
}
