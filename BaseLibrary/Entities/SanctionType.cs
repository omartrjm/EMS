

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class SanctionType
    {
		// many to one relationship
		[JsonIgnore]
		public List<Sanction>? Sanctions { get; set; }
    }
}
