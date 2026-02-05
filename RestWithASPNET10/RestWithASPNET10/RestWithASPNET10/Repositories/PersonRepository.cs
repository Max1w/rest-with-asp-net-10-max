using RestWithASPNET10.Models;
using RestWithASPNET10.Models.Context;
using RestWithASPNET10.Repositories.Interface;

namespace RestWithASPNET10.Repositories
{
    public class PersonRepository : IPersonRepository
    {
		private readonly MSSQLContext _context;

		public PersonRepository(MSSQLContext context)
		{
			_context = context;
		}

		public List<Person> FindAll()
		{
			return _context.Persons.ToList();
		}

		public Person FindById(long id)
		{
			return _context.Persons.Find(id);
		}

		public Person Create(Person person)
		{
			_context.Add(person);
			_context.SaveChanges();
			return person;
		}

		public Person Update(Person person)
		{
			var existingPerson = FindById(person.Id);
			if (existingPerson == null)
				throw new KeyNotFoundException($"O registro com ID {person.Id} não foi encontrado.");

			_context.Entry(existingPerson).CurrentValues.SetValues(person);
			_context.SaveChanges();
			return person;
		}

		public void Delete(long id)
		{
			var existingPerson = FindById(id);
			if (existingPerson == null)
				throw new KeyNotFoundException($"O registro com ID {id} não foi encontrado.");
			_context.Remove(existingPerson);
			_context.SaveChanges();
			return;
		}
	}
}
