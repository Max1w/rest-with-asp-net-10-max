using RestWithASPNET10.Models.Base;

namespace RestWithASPNET10.Repositories.Interface
{
    public interface IRepository<T> where T : BaseEntity
	{
		List<T> FindAll();
		T FindById(long id);
		T Create(T item);
		T Update(T item);
		void Delete(long id);
		bool Exists(long id);
	}
}
