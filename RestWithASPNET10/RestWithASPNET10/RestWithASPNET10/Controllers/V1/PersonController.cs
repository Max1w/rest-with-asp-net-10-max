using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Data.DTO.V1;
using RestWithASPNET10.Service.Person.Interface;

namespace RestWithASPNET10.Controllers.V1
{
	[ApiController]
	[Route("api/[controller]/v1")]
	public class PersonController : ControllerBase
	{
		private readonly IPersonService _personService;
		private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonService personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        [HttpGet]
		public IActionResult Get()
		{
			_logger.LogInformation("Fetching all peoples");
			return Ok(_personService.FindAll());
		}

		[HttpGet("{id}")]
		public IActionResult Get(long id)
		{
			_logger.LogInformation("Fetching peoples with ID {id}", id);
			var person = _personService.FindById(id);

			if (person == null)
			{
				_logger.LogWarning("Person with ID {id} not found", id);
				return NotFound();
			};

			return Ok(person);
		}

		[HttpPost]
		public IActionResult Post([FromBody] PersonDTO person)
		{
			_logger.LogInformation("Creating new Person: {firstName}", person.FirstName);
			var createdPerson = _personService.Create(person);

			if (createdPerson == null) 
			{
				_logger.LogError("Failed to create person: {firstName}", person.FirstName);
				return NotFound();
			};

			_logger.LogDebug("Person created with successfully: {firstName}", createdPerson.FirstName);
			return Ok(createdPerson);
		}

		[HttpPut]
		public IActionResult Put([FromBody] PersonDTO person)
		{
			_logger.LogInformation("Updating person with ID {id}", person.Id);
			var createdPerson = _personService.Update(person);

			if (createdPerson == null)
			{
				_logger.LogError("Person with ID {id} not found for update", person.Id);
				return NotFound();
			};

			_logger.LogDebug("Person updated successfully: {firstName}", createdPerson.FirstName);
			return Ok(createdPerson);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			_logger.LogInformation("Deleting person with ID {id}", id);
			_personService.Delete(id);

			_logger.LogDebug("Person with ID {id} deleted successfully", id);
			return NoContent();
		}
	}
}
