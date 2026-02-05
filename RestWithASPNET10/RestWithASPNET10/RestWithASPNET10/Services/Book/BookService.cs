using RestWithASPNET10.Repositories.Interface;
using RestWithASPNET10.Services.Book.Interface;

namespace RestWithASPNET10.Services.Book
{
    public class BookService : IBookService
	{
		private readonly IBookRepository _repositoryBook;

		public BookService(IBookRepository repositoryBook)
		{
			_repositoryBook = repositoryBook;
		}

		public List<Models.Book> FindAll()
		{
			return _repositoryBook.FindAll();
		}

		public Models.Book FindById(long id)
		{
			return _repositoryBook.FindById(id);
		}

		public Models.Book Create(Models.Book book)
		{
			return _repositoryBook.Create(book);
		}

		public Models.Book Update(Models.Book book)
		{
			return _repositoryBook.Update(book);
		}

		public void Delete(long id)
		{
			_repositoryBook.Delete(id);
		}
	}
}
