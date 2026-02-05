using RestWithASPNET10.Models;
using RestWithASPNET10.Models.Context;
using RestWithASPNET10.Repositories.Interface;
using static System.Reflection.Metadata.BlobBuilder;

namespace RestWithASPNET10.Repositories
{
    public class BookRepository : IBookRepository
	{
		private readonly MSSQLContext _context;

		public BookRepository(MSSQLContext context)
		{
			_context = context;
		}

		public List<Book> FindAll()
		{
			return _context.Books.ToList();
		}

		public Book FindById(long id)
		{
			return _context.Books.Find(id);
		}

		public Book Create(Book Book)
		{
			_context.Add(Book);
			_context.SaveChanges();
			return Book;
		}

		public Book Update(Book Book)
		{
			var existingBook = FindById(Book.Id);
			if (existingBook == null)
				throw new KeyNotFoundException($"O registro com ID {Book.Id} não foi encontrado.");

			_context.Entry(existingBook).CurrentValues.SetValues(Book);
			_context.SaveChanges();
			return Book;
		}

		public void Delete(long id)
		{
			var existingBook = FindById(id);
			if (existingBook == null)
				throw new KeyNotFoundException($"O registro com ID {id} não foi encontrado.");
			_context.Remove(existingBook);
			_context.SaveChanges();
			return;
		}
	}
}
