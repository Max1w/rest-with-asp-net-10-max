using RestWithASPNET10.JsonSerielizers;
using System.Text.Json.Serialization;

namespace RestWithASPNET10.Data.DTO.V1
{
    public class PersonDTO
	{
		[JsonPropertyOrder(2)]
		[JsonPropertyName("code")]
		public long Id { get; set; }

		[JsonPropertyOrder(3)]
		[JsonPropertyName("first_name")]
        public string FirstName { get; set; }

		[JsonPropertyOrder(4)]
		[JsonPropertyName("last_name")]
		public string LastName { get; set; }

		[JsonPropertyOrder(1)]
		public string Address { get; set; }

		[JsonPropertyOrder(5)]
		[JsonConverter(typeof(GenderSerializer))]
		public string Gender { get; set; }
	}
}
