using Bookman.Data;

namespace Bookman.Models
{
    public class BookRepository : IBookRepository
	{
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> AllBooks
        {
            get
            {
                return _context.Books.OrderByDescending(b => b.Date).ToList();
            }
        }

        public Book? GetBookById(int bookId) => _context.Books.FirstOrDefault(b => b.Id == bookId);

        public void CreateBook(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetBooks(string? searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return _context.Books.OrderByDescending(b => b.Date).ToList();
            }

            searchString = searchString.Trim();
            return _context.Books.Where(b => b.Name
                    .Contains(searchString))
                    .OrderBy(b => b.Date).ToList();
        }

        public IEnumerable<Book> FilterBooksBy(string filter)
        {
            if (filter.ToLower() == "name")
            {
                return _context.Books.OrderBy(b => b.Name).ToList();
            }
            else if (filter.ToLower() == "price")
            {
                return _context.Books.OrderBy(b => b.Price).ToList();
            }
            else
            {
                return _context.Books.OrderByDescending(b => b.Date).ToList();
            }
        }
    }
}

