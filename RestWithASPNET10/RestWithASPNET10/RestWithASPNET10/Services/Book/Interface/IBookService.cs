using RestWithASPNET10.Data.DTO.V1;

namespace RestWithASPNET10.Services.Book.Interface
{
    public interface IBookService
    {
		BookDTO Create(BookDTO book);
		BookDTO FindById(long id);
		List<BookDTO> FindAll();
		BookDTO Update(BookDTO book);
		void Delete(long id);
	}
}
