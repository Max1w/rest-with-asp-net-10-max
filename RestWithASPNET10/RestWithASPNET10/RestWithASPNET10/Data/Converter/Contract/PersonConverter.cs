using RestWithASPNET10.Data.Converter.Contract.Interface;
using RestWithASPNET10.Data.DTO.V1; //V2
using RestWithASPNET10.Models;

namespace RestWithASPNET10.Data.Converter.Contract
{
    public class PersonConverter : IParser<Person, PersonDTO>, IParser<PersonDTO, Person>
	{
        public Person Parse(PersonDTO origin)
        {
            if (origin == null) return null;
            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender,
			};
		}

		public List<Person> ParseList(List<PersonDTO> origin)
		{
			if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
		}

		public PersonDTO Parse(Person origin)
        {
			if (origin == null) return null;
            return new PersonDTO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
				Gender = origin.Gender,
			};
		}

        public List<PersonDTO> ParseList(List<Person> origin)
        {
			if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
		}

        
    }
}
