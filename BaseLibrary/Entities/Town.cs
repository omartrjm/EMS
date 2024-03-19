

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Town : BaseEntity
    {
		// one to many relationship
		[JsonIgnore]
		public List<Employee>? Employees { get; set; }

        // many to one relationship
        public City? City { get; set; }
        public int CityId {get; set;}
    }
}
