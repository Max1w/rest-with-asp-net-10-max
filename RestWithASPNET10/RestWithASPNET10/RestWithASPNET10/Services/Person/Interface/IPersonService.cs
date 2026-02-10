using RestWithASPNET10.Data.DTO.V1;

namespace RestWithASPNET10.Service.Person.Interface
{
    public interface IPersonService
    {
		PersonDTO Create(PersonDTO person);
		PersonDTO FindById(long id);
		List<PersonDTO> FindAll();
		PersonDTO Update(PersonDTO person);
		void Delete(long id);
	}
}
