

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class City : BaseEntity
    {
        // many to one relationship 
        public Country? Country { get; set; }
        public int CountryId { get; set; }

		// one to many relationship
		[JsonIgnore]
		public List<Town>? Towns { get; set; }
    }
}
