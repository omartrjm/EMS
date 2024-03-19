

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class VacationType
    {
		// many to one
		[JsonIgnore]
		public List<Vacation> Vacations { get; set; }
    }
}
