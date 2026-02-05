namespace RestWithASPNET10.Services.Book.Interface
{
    public interface IBookService
    {
		Models.Book Create(Models.Book book);
		Models.Book FindById(long id);
		List<Models.Book> FindAll();
		Models.Book Update(Models.Book book);
		void Delete(long id);
	}
}
