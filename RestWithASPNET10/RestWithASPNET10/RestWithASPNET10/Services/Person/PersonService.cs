using RestWithASPNET10.Repositories.Interface;
using RestWithASPNET10.Service.Person.Interface;

namespace RestWithASPNET10.Services.Person
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repositoryPerson;

        public PersonService(IPersonRepository repositoryPerson)
        {
            _repositoryPerson = repositoryPerson;
        }

        public List<Models.Person> FindAll()
		{
			return _repositoryPerson.FindAll();
		}

		public Models.Person FindById(long id)
        {
			return _repositoryPerson.FindById(id);
		}

        public Models.Person Create(Models.Person person)
        {
			return _repositoryPerson.Create(person);
		}

        public Models.Person Update(Models.Person person)
        {
			return _repositoryPerson.Update(person);
		}

        public void Delete(long id)
        {
			_repositoryPerson.Delete(id);
		}
	}
}
