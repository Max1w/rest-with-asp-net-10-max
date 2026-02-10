using Mapster;
using RestWithASPNET10.Data.DTO.V1;
using RestWithASPNET10.Repositories.Interface;
using RestWithASPNET10.Services.Book.Interface;

namespace RestWithASPNET10.Services.Book
{
    public class BookService : IBookService
	{
		private readonly IRepository<Models.Book> _repositoryBook;

		public BookService(IRepository<Models.Book> repositoryBook)
		{
			_repositoryBook = repositoryBook;
		}

		public List<BookDTO> FindAll()
		{
			return _repositoryBook.FindAll()
						.Adapt<List<BookDTO>>();
		}

		public BookDTO FindById(long id)
		{
			return _repositoryBook.FindById(id)
						.Adapt<BookDTO>();
		}

		public BookDTO Create(BookDTO book)
		{
			var entity = book.Adapt<Models.Book>();
			entity = _repositoryBook.Create(entity);
			return entity.Adapt<BookDTO>();
		}

		public BookDTO Update(BookDTO book)
		{
			var entity = book.Adapt<Models.Book>();
			entity = _repositoryBook.Update(entity);
			return entity.Adapt<BookDTO>();
		}

		public void Delete(long id)
		{
			_repositoryBook.Delete(id);
		}
	}
}
