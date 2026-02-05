namespace RestWithASPNET10.Service.Person.Interface
{
    public interface IPersonService
    {
		Models.Person Create(Models.Person person);
		Models.Person FindById(long id);
		List<Models.Person> FindAll();
		Models.Person Update(Models.Person person);
		void Delete(long id);
	}
}
