using FluentAssertions;
using RestWithASPNET10.Data.Converter.Contract;
using RestWithASPNET10.Data.DTO.V1;
using RestWithASPNET10.Models;

namespace RestWithASPNET10.Tests
{ 
    public class PersonConverterTests
    {
        private readonly PersonConverter _converter;

        public PersonConverterTests()
        {
            _converter = new PersonConverter();
        }

        [Fact]
        public void ParseShouldConverterPersonDTOToPerson()
        {
            //Arrange
            var dto = new PersonDTO
            {
                Id = 1,
                FirstName = "Mahtma",
                LastName = "Gandhi",
                Address = "Porbandan - India",
                Gender = "Male"
			};

            //Act
            var person = _converter.Parse(dto);

            //Assert
            person
                .Should()
                .NotBeNull();
            person.Id
                .Should()
                .Be(dto.Id);
            person.Gender
                .Should()
                .Be(dto.Gender);
            person.Address
                .Should()
                .Be(dto.Address);
            person.FirstName
                .Should()
                .Be(dto.FirstName);
            person.LastName
                .Should()
                .Be(dto.LastName);
            person
                .Should()
                .BeEquivalentTo(dto);

			//Assert.NotNull(person);
			//Assert.Equal(dto.Id, person.Id);
			//Assert.Equal(dto.FirstName, person.FirstName);
			//Assert.Equal(dto.LastName, person.LastName);
			//Assert.Equal(dto.Address, person.Address);
			//Assert.Equal(dto.Gender, person.Gender);
		}

        [Fact]
        public void ParseNullPersonDTOToPersonShouldReturnNull()
        { 
            //Arrange
                PersonDTO dto = null;
			//Act
			    var person = _converter.Parse(dto);
			//Assert
			person
				.Should()
                    .BeNull();
		}

		[Fact]
		public void ParseShouldConverterPersonToPersonDTO()
		{
            //Arrange
            var person = new Person
            {
                Id = 1,
                FirstName = "Mahtma",
                LastName = "Gandhi",
                Address = "Porbandan - India",
                Gender = "Male",
                Birthday = new DateTime(1869, 10, 2)
			};

			//Act
            var dto = _converter.Parse(person);

			//Assert
            dto
                .Should()
                .NotBeNull();
            dto.Id
                .Should()
                .Be(person.Id);
            dto.Address
                .Should()
                .Be(person.Address);
            dto.FirstName
                .Should()
                .Be(person.FirstName);
            dto.Gender
                .Should()
                .Be(person.Gender);
            dto.LastName
                .Should()
                .Be(person.LastName);
            dto
                .Should()
                .BeEquivalentTo(person, options => 
                options.Excluding(person => person.Birthday));
		}

		[Fact]
		public void ParseNullPersonToPersonDTOShouldReturnNull()
		{
			//Arrange
			Person person = null;
			//Act
			var dto = _converter.Parse(person);
			//Assert
			person
				.Should()
					.BeNull();
		}
	}
}