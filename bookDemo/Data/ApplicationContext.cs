using bookDemo.Models;

namespace bookDemo.Data
{
    public static class ApplicationContext
    {
        public static List<Book> Books { get; set; }
        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book(){Id=1, Title="Karagoz ve hacivat", Price=75},
                new Book(){Id=2, Title="OYeah", Price=150},
                new Book(){Id=3, Title="Dede", Price=75},
            };
        }
    }
}
