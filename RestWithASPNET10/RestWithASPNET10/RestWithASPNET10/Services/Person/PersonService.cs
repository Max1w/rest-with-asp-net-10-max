using RestWithASPNET10.Data.Converter.Contract;
using RestWithASPNET10.Data.DTO.V1;
using RestWithASPNET10.Repositories.Interface;
using RestWithASPNET10.Service.Person.Interface;

namespace RestWithASPNET10.Services.Person
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Models.Person> _repositoryPerson;
        private readonly ILogger<PersonService> _logger;
        private readonly PersonConverter _converter;

        public PersonService(IRepository<Models.Person> repositoryPerson, ILogger<PersonService> logger)
        {
            _repositoryPerson = repositoryPerson;
            _logger = logger;
            _converter = new PersonConverter();
        }

        public List<PersonDTO> FindAll()
		{
			return _converter.ParseList(_repositoryPerson.FindAll());
		}

		public PersonDTO FindById(long id)
        {
			return _converter.Parse(_repositoryPerson.FindById(id));
		}

        public PersonDTO Create(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            entity = _repositoryPerson.Create(entity);
			return _converter.Parse(entity);
		}

        public PersonDTO Update(PersonDTO person)
        {
			var entity = _converter.Parse(person);
            entity = _repositoryPerson.Update(entity);
			return _converter.Parse(entity);
		}

        public void Delete(long id)
        {
			_repositoryPerson.Delete(id);
		}
	}
}
