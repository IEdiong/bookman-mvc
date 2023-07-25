namespace Bookman.Models
{
	public interface IBookRepository
	{
		IEnumerable<Book> AllBooks { get; }
		Book? GetBookById(int bookId);
		void CreateBook(Book book);
		IEnumerable<Book> GetBooks(string? searchString);
	}
}