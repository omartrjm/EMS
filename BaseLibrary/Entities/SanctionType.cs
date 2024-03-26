

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class SanctionType : BaseEntity
    {
		// many to one relationship
		[JsonIgnore]
		public List<Sanction>? Sanctions { get; set; }
    }
}
