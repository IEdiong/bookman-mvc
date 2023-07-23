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
                return _context.Books.ToList();
            }
        }

        public Book? GetBookById(int bookId) => _context.Books.FirstOrDefault(b => b.Id == bookId);

        public void CreateBook(Book book)
        {
            _context.Add(book);
            _context.SaveChanges();
        }
    }
}

