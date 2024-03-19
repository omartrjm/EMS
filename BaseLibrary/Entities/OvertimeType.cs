

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class OvertimeType
    {
		// Many to one relationship with Overtime
		[JsonIgnore]
		public List<Overtime>? Overtimes { get; set; }
	}
}
